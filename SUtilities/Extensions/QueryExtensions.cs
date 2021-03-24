using System;
using System.Collections.Generic;

namespace STools.Extensions
{
    public static class QueryExtensions
    {
        public static ICollection<int> IndexesOf<T>(this List<T> List, T Comparison)
            where T : class
        {
            if (List is null) {
                throw new ArgumentNullException(nameof(List));
            } else if (Comparison is null) {
                throw new ArgumentNullException(nameof(Comparison));
            }

            List<int> Indexes = new();

            for (int i = 0; i < List.Count; i++) {
                if (List[i] == Comparison) {
                    Indexes.Add(i);
                }
            }

            return Indexes;
        }

        public static ICollection<int> IndexesOf<T>(this List<T> List, Func<T, bool> Predicate)
        {
            if (List is null) {
                throw new ArgumentNullException(nameof(List));
            } else if (Predicate is null) {
                throw new ArgumentNullException(nameof(Predicate));
            }

            List<int> Indexes = new();

            for (int i = 0; i < List.Count; i++) {
                if (Predicate(List[i]))
                    Indexes.Add(i);
            }

            return Indexes;
        }
    }
}