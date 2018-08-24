using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApp
{
    public static class MyExtensions
    {
        public enum SortDirection
        {
            descending = 0,
            ascending = 1,
        }

        public static IEnumerable<TSource> OrderBy<TSource, TKey, TSortDirection>(this IEnumerable<TSource> src, Func<TSource, TKey> f, SortDirection order = SortDirection.ascending)
        {

            switch (order)
            {
                case SortDirection.descending:
                    return src.OrderByDescending(f);
                case SortDirection.ascending:
                default:
                    return src.OrderBy(f);
            }
        }
    }
}
