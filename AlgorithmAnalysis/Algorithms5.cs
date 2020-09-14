using System;
using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    public class Algorithms5
    {
        // Record should be indexed by the combination of pk_1 and pk_2 (each are part of the "primary key"). 
        // The order of priorities for the solution should be: Correctness, Performance, and Style.
        public class Record
        {
            public int PK_1 { get; set; }
            public int PK_2 { get; set; }
            public string Value { get; set; }
        }

        private SortedList<string, Record> _cache;
        private List<string> _index;

        // Create an effecient cache of records as a field.
        // The structure of a cache should not be a .NET MemoryCache. Use your own data structure.
        public void LoadRecordsIntoCache(IEnumerable<Record> records)
        {
            _cache = new SortedList<string, Record>();
            foreach (Record r in records) {
                string key = $"{r.PK_1}_{r.PK_2}";
                _cache.Add(key, r);
            }
            Console.WriteLine($"{_cache.Count} records loaded to cache.");
        }

        public Record GetRecord(int pk_1, int pk_2)
        {
            // Implement GetRecord. Need to retrieve value from the cache. Retrieval should be very fast.
            string key = $"{pk_1}_{pk_2}";
            int cnt = _cache.Count;
            int idx = _index.BinarySearch(key);
            return _cache.Values[idx];
            // return null;
        }

        public void Init() {
            List<Record> records = new List<Record>();
            records.Add(new Record {PK_1 = 5, PK_2 = 8, Value = "57"});
            records.Add(new Record {PK_1 = 3, PK_2 = 8, Value = "38"});
            records.Add(new Record {PK_1 = 1, PK_2 = 8, Value = "18"});
            records.Add(new Record {PK_1 = 5, PK_2 = 6, Value = "56"});
            records.Add(new Record {PK_1 = 3, PK_2 = 6, Value = "36"});
            records.Add(new Record {PK_1 = 1, PK_2 = 6, Value = "16"});
            records.Add(new Record {PK_1 = 5, PK_2 = 2, Value = "52"});
            records.Add(new Record {PK_1 = 3, PK_2 = 2, Value = "32"});
            records.Add(new Record {PK_1 = 1, PK_2 = 2, Value = "12"});
            records.Add(new Record {PK_1 = 5, PK_2 = 4, Value = "54"});
            records.Add(new Record {PK_1 = 3, PK_2 = 4, Value = "34"});
            records.Add(new Record {PK_1 = 1, PK_2 = 4, Value = "14"});
            LoadRecordsIntoCache(records);
            string[] temp = new string[_cache.Count];
            _cache.Keys.CopyTo(temp, 0);
            _index = new List<string>(temp); // why? because MS didn't put BinarySearch method on SortedList or IList (IList<T> SortedList.Keys)
        }
    }
}
