using System.IO;
using System.Collections.Generic;
using System;

namespace LinqApp {
    public enum Gender {
        Female,
        Male
    }

    public class Record {
        public string Name { get; }
        public Gender Gender { get; }
        public int Rank { get; set; }

        public Record(string name, Gender gender, int rank) {
            Name = name;
            Gender = gender;
            Rank = rank;
        }

        public override string ToString() {
            return $"{Gender}\t{Rank}\t{Name}";
        }
    }

    // Declare the comparer
    class RecordComparer : IEqualityComparer<Record>, IComparer<Record> {
        public int Compare(Record x, Record y)
        {
           if (x.Rank < y.Rank) {
                return -1;
            } else if (x.Rank > y.Rank) {
                return 1;
            }

            if (x.Gender < y.Gender) {
                return -1;
            } else if (x.Gender > y.Gender) {
                return 1;
            }

            return String.Compare(x.Name, y.Name);
        }

        public bool Equals(Record x, Record y) {
            return x.Name == y.Name && x.Gender == y.Gender && x.Rank == y.Rank;
        }

        public int GetHashCode(Record obj) {
            return obj.GetHashCode();
        }
    }

    public class DataLoader {

        private static IEnumerable<Record> Load(string file, Gender gender) {
            var reader = new StreamReader(File.OpenRead(file));
            while (!reader.EndOfStream) {
                var values = reader.ReadLine().Split(',');
                yield return new Record(values[1], gender, int.Parse(values[0]));
            }
        }

        public static IList<Record> Load(string folder) {
            var records = new List<Record>();
            records.AddRange(Load(Path.Combine(folder, "female.csv"), Gender.Female));
            records.AddRange(Load(Path.Combine(folder, "male.csv"), Gender.Male));
            return records;
        }
    }
}