using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CrosswordSolver
{
    //***********************************Instructions********************************
    /*
    *Implement a Crossword Solver
    * 1. User needs to be able to input a pattern of a combination of known letters and wildcards. 
    *  The input format should use an asterisk: '*' (U+002A) as a wildcard.
    *  Make this simple!
    *  
    * 2. The program should return all words in the dictionary that match the input pattern. 
    *  This means you won't be solving a whole crossword - just providing options for what would 
    *  fit in a crossword row or column.
    *      
    *  Example Input: b**r
    *  Output: Results: Bear, Beer, Bier, Birr, Blur, Boar, Boor, Brrr, Buhr, Burr. Found 5 words in 1000 ms
    *   
    *  Example Input: *eel
    *  Output: Results: Feel, Heel, Keel, Peel, Reel, Seel, Teel, Weel. Found 8 words in 1000 ms
    *   
    * 3. An example dictionary .csv is included for your convenience. You can/should use the default .NET libraries to load it.
    * 4. Using the stopwatch, be sure to indicate how long your solution takes to load its structures, and produce a result. 
    *      Hint: display the time to process a result AFTER printing them out, otherwise you won't be able to see it in large result sets.
    * 
    * A few final points:
    * 1. The order of priorities for the solution should be: Correctness, Performance, elegance, and usability.
    * 2. Startup time and memory usage are much less important than the time taken to solve the crossword pattern (which is critical).
    * 3. Error handling and input validation are nice to haves, as long as your control schemes and instructions are clear.
    * 
    */

    public class Program
    {
        static Dictionary<int, List<string>> wordLists = null;
        static void Main(string[] args)
        {
            Console.WriteLine($"{"+".PadRight(20, '+')} RunCrosswordSolver {"+".PadRight(20, '+')}");
            RunCrosswordSolver();
            Console.WriteLine($"{"+".PadRight(20, '+')} RunAlgorithms1 {"+".PadRight(20, '+')}");
            RunAlgorithms1();
            Console.WriteLine($"{"+".PadRight(20, '+')} RunAlgorithms2 {"+".PadRight(20, '+')}");
            RunAlgorithms2();
            Console.WriteLine($"{"+".PadRight(20, '+')} RunAlgorithms3 {"+".PadRight(20, '+')}");
            RunAlgorithms3();
            Console.WriteLine($"{"+".PadRight(20, '+')} RunAlgorithms4 {"+".PadRight(20, '+')}");
            RunAlgorithms4();
            Console.WriteLine($"{"+".PadRight(20, '+')} RunAlgorithms5 {"+".PadRight(20, '+')}");
            RunAlgorithms5();
        }

        static void RunAlgorithms1() {
            List<AlgorithmAnalysis.GrowthTableRow> rows = new List<AlgorithmAnalysis.GrowthTableRow>();
            rows.Add(new AlgorithmAnalysis.GrowthTableRow(1, 4, .1m));
            rows.Add(new AlgorithmAnalysis.GrowthTableRow(8, 10, .17m));
            rows.Add(new AlgorithmAnalysis.GrowthTableRow(5, 7, .05m));
            rows.Add(new AlgorithmAnalysis.GrowthTableRow(11, 53, .68m));
            AlgorithmAnalysis.GrowthTable gt = new AlgorithmAnalysis.GrowthTable(rows);
            bool result = AlgorithmAnalysis.Algorithms1.IsValid(gt);
            Console.WriteLine($"Growth Table Valid == {result}");
        }

        static void RunAlgorithms2() {
            List<int> n = new List<int>(new int[] {1,2,3,4,5,6,7,8,9,10});
            foreach (List<int> list in AlgorithmAnalysis.Algorithms2.Batch<int>(n, 3)) {
                Console.WriteLine(string.Join(", ", list.ToArray()) );
            }
        }

        static void RunAlgorithms3() {
            List<string> list1 = AlgorithmAnalysis.Algorithms3.SortByLastNameThenFirstName();
            foreach (string item in list1) {
                Console.WriteLine(item);
            }
            Console.WriteLine("-".PadRight(50, '-'));
            
            List<string> list2 = AlgorithmAnalysis.Algorithms3.CountsByFirstName();
            foreach (string item in list2) {
                Console.WriteLine(item);
            }
        }

        static void RunAlgorithms4() {
            var al4 = new AlgorithmAnalysis.Algorithms4();
            al4.SaveLines("english.csv", "al4out.txt");
        }

        static void RunAlgorithms5() {
            var al5 = new AlgorithmAnalysis.Algorithms5();
            al5.Init();
            var result = al5.GetRecord(3, 4);
            Console.WriteLine($"3, 4 - {result.Value}");
        }

        static void RunCrosswordSolver() {
            var sw = new Stopwatch();
            sw.Start();
            Setup();
            sw.Stop();
            Console.WriteLine($"Setup Elapsed Time: {sw.ElapsedMilliseconds} ms");

            Console.Write("Input search template (* == wildcard): ");
            string userInput = Console.ReadLine();
            sw = new Stopwatch();
            sw.Start();
            var result = GetPossibleWords(userInput);
            sw.Stop();
            string rDisplay = String.Join(", ", result.ToArray());
            Console.WriteLine($"Results: {rDisplay}. Found {result.Count} words in {sw.ElapsedMilliseconds} ms");
        }

        //Perform any loading or setup here. Do your best to not change this method signature.
        public static void Setup()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"english.csv");
            wordLists = new Dictionary<int, List<string>>();
            while ((line = file.ReadLine()) != null)
            {
                int len = line.Length;
                List<string> wordList = null;
                if (wordLists.ContainsKey(len))
                {
                    wordList = wordLists[len];
                }
                else
                {
                    wordList = new List<string>();
                    wordLists.Add(len, wordList);
                }
                wordList.Add(line);
                // System.Console.WriteLine($"{len}: {line}");
                counter++;
            }

            file.Close();
        }

        //Return results from here. Do your best to not change this method signature.
        public static List<string> GetPossibleWords(string template)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(template)) { return result; }
            string search = template.ToUpper();
            int len = search.Length;
            if (!wordLists.ContainsKey(len)) { return result; }
            List<string> wordList = wordLists[len];

            foreach (string word in wordList)
            {
                bool fail = false;
                for (int i = 0; i < len; i++)
                {
                    char c = search[i];
                    if ('*' == c) { continue; }
                    if (word[i] == c) { continue; }

                    fail = true;
                    break;
                }
                if (!fail) { result.Add(word); }
            }

            return result;
        }
    }
}
