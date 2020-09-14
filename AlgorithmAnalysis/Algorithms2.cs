using System.Collections.Generic;

namespace AlgorithmAnalysis
{
    public static class Algorithms2
    {
        // Implement this function. I would like to return a stream of batches of size <= maxBatchSize while enumerating over the input enumerable.
        // Each batch is defined as a List<T> where List<T>.Count <= maxBatchSize
        public static IEnumerable<List<T>> Batch<T>(this IEnumerable<T> enumerable, int maxBatchSize)
        {
            // Code...
            int idx = 0;
            List<T> result = new List<T>();
            foreach (T item in enumerable) {
                if (idx++ < maxBatchSize) { result.Add(item); }
                else {
                    yield return result;
                    idx = 1;
                    result = new List<T>();
                    result.Add(item);
                }
            }
            yield return result;
            yield break;
        }
    }
}
