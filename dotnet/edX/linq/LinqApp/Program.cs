using System;
using System.IO;
using System.Linq;
using static LinqApp.MyExtensions;
using static LinqApp.MyExtensions.SortDirection;
using System.Collections.Generic;
using ConsoleTables;
using System.Collections;

namespace LinqApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqToObject.Execute();

            // var folder = Path.Combine(Environment.CurrentDirectory, "..");
            // var records = DataLoader.Load(folder);

            //JoinOperations(records);
            //GroupingOperations(records);
            //AggregationOperations();

            //EqualityOperations();
            //DataTypeConversionOperations(records);
            //GenerationOperations();
            //PartioningOperations();
            //SingleElementOperators();
            //ProjectionOperations(records);

            // UseIComparer(records);
            //ConcatVsUnion();
            //SetOperations();
            //UseIEqualityComparer(records);
            //Top10MaleFemale(records);
        }

        private static void JoinOperations(IList<Record> records)
        {
            // Note: Name[0] refers to first char in Name

            #region GroupJoin
            // perform left outer join chars A-Z and groups
            var maleTop20 = records
                .Where(r => r.Gender == Gender.Male && r.Rank <= 20);

            // version 2
            var alphabet = Enumerable.Range('A', 26).Select(e => (char)e);

            // next 3 GroupJoin styles yield same results
            var result = from c in alphabet
                join r in maleTop20
                on c equals r.Name[0] into g
                select (Start: c, Names: String.Join(",", g.Select(r => r.Name)));

            // var result = alphabet.GroupJoin(
            //     maleTop20,
            //     c => c, r => r.Name[0],
            //     (c, g) => (Start: c, Names: String.Join(",", g.Select(r => r.Name)))
            //  );

            // var result = Enumerable.GroupJoin(
            //     alphabet, maleTop20,
            //     c => c, r => r.Name[0],
            //     (c, g) => (Start: c, Names: String.Join(",", g.Select(r => r.Name)))
            //  );

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Start}: {item.Names}");
            }

            // version 1 - not quite there
            // var result = maleTop20.ToLookup(r => r.Name[0], r => r.Name).OrderBy(g => g.Key);
            // foreach (var item in result) {
            //     Console.WriteLine($"{item.Key}: {string.Join(",", item)}");
            // }

            #endregion

            #region Join
            // all 3 versions in region yield equivalent results
            // var maleTop5 = records
            //     .Where(r => r.Gender == Gender.Male && r.Rank <= 5);
            // var femaleTop5 = records
            //     .Where(r => r.Gender == Gender.Female && r.Rank <= 5);

            // version 3
            // var result = from mr in maleTop5
            //              join fr in femaleTop5
            //              on mr.Rank equals fr.Rank
            //              select (Rank: mr.Rank, Male: mr.Name, Female: fr.Name);

            // version 2
            // var result = maleTop5.Join(
            //         femaleTop5,
            //         r => r.Rank, r => r.Rank,
            //         (mr, fr) => (Rank: mr.Rank, Male: mr.Name, Female: fr.Name)
            //      );

            // version 1
            // var result = Enumerable.Join(
            //         maleTop5, femaleTop5,
            //         r => r.Rank, r => r.Rank,
            //         (mr, fr) => (Rank: mr.Rank, Male: mr.Name, Female: fr.Name)
            //      );

            // System.Console.WriteLine($"Rank\tMale\tFemale");
            // foreach (var item in result)
            // {
            //     System.Console.WriteLine($"{item.Rank}\t{item.Male}\t{item.Female}");
            // }
            #endregion
        }

        private static void GroupingOperations(IList<Record> records)
        {
            // Note: Name[0] refers to first char in Name
            var femaleTop30 = records
                .Where(r => r.Rank <= 30 && r.Gender == Gender.Female)
                .OrderBy(r => r.Name);

            var result1 = femaleTop30.GroupBy(r => r.Name[0], r => r.Name)
                .Select(g => (Key: g.Key, Count: g.Count(), Names: String.Join(",", g)));

            var result2 = from r in femaleTop30
                          group r.Name by r.Name[0] into g
                          select (Key: g.Key, Count: g.Count(), Names: String.Join(",", g));

            foreach (var e in result1)
            {
                Console.WriteLine($"Key:{e.Key} Count:{e.Count} Names:{e.Names}");
            }

            // var groups1 = femaleTop30.GroupBy(r => r.Name[0]);
            // var groups2 = from r in femaleTop30 group r by r.Name[0];

            // var groups3 = femaleTop30.GroupBy(r => r.Name[0], r => r.Name);
            // var groups4 = from r in femaleTop30 group r.Name by r.Name[0];

            // foreach (var g in groups3)
            // {
            //     Console.WriteLine($"Key:{g.Key} Count:{g.Count()} Names:{String.Join(",", g)}");
            // }
        }

        private static void AggregationOperations()
        {
            double[] source = { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0 };
            var max = source.Max();
            var min = source.Min();
            var sum = source.Sum();
            var count = source.Count();
            var longCount = source.LongCount();
            var avg = source.Average();
            var result = source
                .Aggregate((variance: 0.0, avg: source.Average(), count: source.Count()),
                (acc, e) =>
                {
                    acc.variance += Math.Pow(e - acc.avg, 2) / acc.count;
                    return acc;
                });

            Console.WriteLine($"{max.GetType().Name} {max}");
            Console.WriteLine($"{min.GetType().Name} {min}");
            Console.WriteLine($"{sum.GetType().Name} {sum}");
            Console.WriteLine($"{count.GetType().Name} {count}");
            Console.WriteLine($"{longCount.GetType().Name} {longCount}");
            Console.WriteLine($"{avg.GetType().Name} {avg}");
            Console.WriteLine($"{result.variance.GetType().Name} {result.variance}");
        }

        class StringEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return String.Compare(x, y, true) == 0;
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }

        private static void EqualityOperations()
        {
            string[] lower = { "aaa", "bbb", "ccc" };
            string[] upper = { "AAA", "BBB", "CCC" };
            var r1 = lower.SequenceEqual(upper);
            var r2 = lower.SequenceEqual(upper, new StringEqualityComparer());
            System.Console.WriteLine(r1);
            System.Console.WriteLine(r2);

            // var array = new int[] { 0, 1, 2, 3, 4, 5 };
            // var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            // var set = new HashSet<int> { 0, 1, 2, 3, 3, 2, 1, 4, 5 }; //ends up with only unique elements
            // var r1 = array.SequenceEqual(list);
            // var r2 = array.SequenceEqual(set);
            // System.Console.WriteLine(r1);
            // System.Console.WriteLine(r2);
        }

        private static void DataTypeConversionOperations(IList<Record> records)
        {
            var maleTop100 = records
                .Where(r => r.Rank <= 100 && r.Gender == Gender.Male);
            var list = maleTop100.ToList();
            var array = maleTop100.ToArray();
            var set = maleTop100.ToHashSet();
            var dict = maleTop100.ToDictionary(r => r.Name, r => r.Rank);

            //creates groupings [0] == ranks 1 - 10, [1] == ranks 11 - 20, etc.
            var lookup = maleTop100.ToLookup(r => (r.Rank - 1) / 10, r => r.Name);

            // Check collection type
            System.Console.WriteLine(maleTop100.GetType());
            System.Console.WriteLine(list.GetType());
            System.Console.WriteLine(array.GetType());
            System.Console.WriteLine(set.GetType());
            System.Console.WriteLine(dict.GetType());
            System.Console.WriteLine(lookup.GetType());
            System.Console.WriteLine(lookup.First().GetType());

            System.Console.WriteLine("=======================");

            // Check values
            System.Console.WriteLine(dict["Timothy"]);
            System.Console.WriteLine(String.Join(",", lookup[0]));

            // var arrayList = new ArrayList() { 100, 200, 300, 400 };
            // var nums = arrayList.Cast<int>();
            // System.Console.WriteLine(nums is IEnumerable<int>);
            // System.Console.WriteLine(String.Join(",", nums));
        }

        static IEnumerable<int> Range(int start, int end)
        {
            if (start <= end)
            {
                return Enumerable.Range(start, end - start + 1);
            }
            else
            {
                return Enumerable.Empty<int>();
            }
        }

        private static void GenerationOperations()
        {
            var defaultGift = "Programming Books";
            string[] wishlist = { "Toy Car", "Video Games", "Skateboard" };
            string[] storeInventory = { "Computer", "Candy", "Flowers" };
            var iGot = wishlist.Intersect(storeInventory).DefaultIfEmpty(defaultGift);

            foreach (var gift in iGot)
            {
                System.Console.WriteLine(gift);
            }

            // var r1 = Range(0, 9);
            // var r2 = Range(9, 0);

            // Console.WriteLine(String.Join(",", r1));
            // Console.WriteLine(String.Join(",", r2));



            // var r1 = Enumerable.Repeat("Hello", 5);
            // var r2 = Enumerable.Range(0, 10);
            // var r3 = Enumerable.Range(0, 10).Select(e => Math.Pow(2, e));
            // var r4 = Enumerable.Range('A', 26).Select(e => (char)e);

            // Console.WriteLine(String.Join(",", r1));
            // Console.WriteLine(String.Join(",", r2));
            // Console.WriteLine(String.Join(",", r3));
            // Console.WriteLine(String.Join(",", r4));

        }

        private static void PartioningOperations()
        {
            string[] source = { "A1", "B1", "C1", "A2", "B2", "C2" };

            var r1 = source.TakeWhile(e => e.StartsWith("A"));
            var r2 = source.TakeWhile(e => !e.StartsWith("C"));
            var r3 = source.TakeWhile(e => e.StartsWith("C"));
            var r4 = source.SkipWhile(e => e.StartsWith("A"));
            var r5 = source.SkipWhile(e => !e.StartsWith("C"));
            var r6 = source.SkipWhile(e => e.StartsWith("C"));

            Console.WriteLine(String.Join(",", r1));
            Console.WriteLine(String.Join(",", r2));
            Console.WriteLine(String.Join(",", r3));
            Console.WriteLine(String.Join(",", r4));
            Console.WriteLine(String.Join(",", r5));
            Console.WriteLine(String.Join(",", r6));

            /*
                        string[] source = { "A1", "A2", "B1", "B2", "C1", "C2" };
                        var r1 = source.Take(3);
                        var r2 = source.Take(100);
                        var r3 = source.Skip(2);
                        var r4 = source.Skip(100);
                        var r5 = source.Skip(2).Take(2);
                        var r6 = source.TakeLast(2);
                        var r7 = source.TakeLast(100);

                        Console.WriteLine(String.Join(",", r1));
                        Console.WriteLine(String.Join(",", r2));
                        Console.WriteLine(String.Join(",", r3));
                        Console.WriteLine(String.Join(",", r4));
                        Console.WriteLine(String.Join(",", r5));
                        Console.WriteLine(String.Join(",", r6));
                        Console.WriteLine(String.Join(",", r7));
             */
        }

        private static void SingleElementOperators()
        {
            string[] names = { "Andrew", "Tim", "Tom", "Rina" };
            var eAt3 = names.ElementAt(3);
            // var eAt4 = array.ElementAt(4);
            var head = names.First();
            var firstT = names.First(n => n.StartsWith("T"));
            // var firstX = array.First(n => n.StartsWith("X"));
            var tail = names.Last();
            var lastT = names.Last(n => n.StartsWith("T"));
            // var lastX = names.Last(n => n.StartsWith("X"));
            // var onlyOne = names.Single();
            var singleA = names.Single(n => n.StartsWith("A"));
            // var singleT = names.Single(n => n.StartsWith("T"));
            // var singleX = names.Single(n => n.StartsWith("X"));
            // var singleOrDefaultT = names.SingleOrDefault(n => n.StartsWith("T"));
            var whereFalse = names.Where(n => false); // not a single element, but thrown in for comparison: never null
            Console.WriteLine($"whereFalse ({whereFalse.GetType()}), Count ({whereFalse.Count()})");
            Console.WriteLine($"{eAt3}, {head}, {firstT}, {tail}, {lastT}, {singleA}");
        }

        class RankAndName
        {
            public int Rank { get; set; }
            public string Name { get; set; }
        }

        private static void ProjectionOperations(IList<Record> records)
        {
            // aka mapping

            UsingSelectMany(records);
            // UsingSelect(records);
        }

        private static void UsingSelectMany(IList<Record> records)
        {
            var dict = new Dictionary<string, IEnumerable<Record>>();
            dict["FemaleTop5"] = records.Where(r => r.Rank <= 5 && r.Gender == Gender.Female);
            dict["MaleTop5"] = records.Where(r => r.Rank <= 5 && r.Gender == Gender.Male);

            Console.WriteLine("Solution 1:");
            Console.WriteLine(new string('-', 78));
            //var names1 = new List<string>();
            var selectResult = dict.Select(kvp => kvp.Value);
            foreach (var c in selectResult)
            {
                foreach (var r in c)
                {
                    Console.WriteLine(r.Name);
                }
            }

            Console.WriteLine("\nSolution 2:");
            Console.WriteLine(new string('-', 78));
            //var names2 = new List<string>();
            var selectManyResult = dict.SelectMany(kvp => kvp.Value);
            foreach (var r in selectManyResult)
            {
                Console.WriteLine(r.Name);
            }

            Console.WriteLine("\nSolution 3:");
            Console.WriteLine(new string('-', 78));
            var names3 =
                from kvp in dict
                from r in kvp.Value
                select r.Name;

            foreach (var item in names3)
            {
                Console.WriteLine(item);
            }

        }

        private static void UsingSelect(IList<Record> records)
        {
            var items = records.Select(r => (r.Rank, r.Name));
            //var items = from r in records select new { Rank = r.Rank, Name = r.Name };
            //var items = records.Select(r => new { Rank = r.Rank, Name = r.Name });
            //var items = from r in records select new RankAndName { Rank = r.Rank, Name = r.Name };
            //var items = records.Select(r => new RankAndName { Rank = r.Rank, Name = r.Name });
            foreach (var item in items)
            {
                System.Console.WriteLine($"Rank:{item.Rank} Name:{item.Name}"); // for Tuple requires C# 7.1; project setting: <LangVersion>latest</LangVersion>
                                                                                //System.Console.WriteLine($"Rank:{item.ToTuple().Item1} Name:{item.ToTuple().Item2}"); // old Tuple code
            }

            /*             var names = from r in records select r.Name;
                        foreach (var n in names)
                        {
                            System.Console.WriteLine(n);
                        }
             */
        }

        private static void UseIComparer(IList<Record> records)
        {
            var sorted = records.OrderBy(r => r, new RecordComparer());
            foreach (var r in sorted)
            {
                System.Console.WriteLine(r.ToString());
            }
        }

        private static void ConcatVsUnion()
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            var concatResult = array1.Concat(array2); // 1,2,3,4,5,3,4,5,6,7
            var unionResult = array1.Union(array2); // 1,2,3,4,5,6,7

            System.Console.WriteLine($"Concat: {string.Join(",", concatResult)}");
            System.Console.WriteLine($"Union: {string.Join(",", unionResult)}");
        }

        private static void SetOperations()
        {
            int[] left = { 1, 1, 2, 3, 3, 4, 4 };
            int[] right = { 3, 4, 5, 6 };

            var distinctResult = left.Distinct();
            var intersectResult = left.Intersect(right);
            var exceptResult = left.Except(right);
            var unionResult = left.Union(right);

            Console.WriteLine($"Distinct: {string.Join(",", distinctResult)}"); // 1, 2, 3, 4
            Console.WriteLine($"Intersect: {string.Join(",", intersectResult)}"); // 3, 4
            Console.WriteLine($"Except: {string.Join(",", exceptResult)}"); // 1, 2
            Console.WriteLine($"Union: {string.Join(",", unionResult)}"); // 1, 2, 3, 4, 5, 6
        }

        private static void UseIEqualityComparer(IList<Record> records)
        {
            var record = new Record("Timothy", Gender.Male, 38);
            var result = records.Contains(record, new RecordComparer()); // use the comparer
            System.Console.WriteLine(result);
        }

        private static void Top10MaleFemale(IList<Record> record)
        {
            var femaleTop10 = record
                //.Where(r => r.Gender == Gender.Female && r.Rank <= 10)
                .Where(r => r.Name.Length <= 3)
                .OrderBy<Record, int, SortDirection>(r => r.Rank, descending)
                .Select(r =>
                {
                    return $"record:\t{r}";
                });

            var maleTop10 = (from r in record
                             where r.Gender == Gender.Male && r.Rank <= 10
                             select r)
                             .OrderBy<Record, int, SortDirection>(r => r.Rank, ascending)
                            .Select(r =>
                            {
                                return $"record:\t{r}";
                            });
            foreach (var r in femaleTop10)
                System.Console.WriteLine(r);
            foreach (var r in maleTop10)
                System.Console.WriteLine(r);
        }
    }
}
