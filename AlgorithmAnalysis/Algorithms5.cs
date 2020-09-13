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

        // Create an effecient cache of records as a field.
        // The structure of a cache should not be a .NET MemoryCache. Use your own data structure.
        public void LoadRecordsIntoCache(IEnumerable<Record> records)
        {
        }

        public Record GetRecord(int pk_1, int pk_2)
        {
            // Implement GetRecord. Need to retrieve value from the cache. Retrieval should be very fast.
            return null;
        }
    }
}
