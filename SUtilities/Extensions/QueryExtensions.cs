using System;
using System.Collections.Generic;

namespace STools.Extensions
{
    public static class QueryExtensions
    {
        public static List<int> IndexesOf<T>(this List<T> List, T Comparison)
            where T : class
        {
            List<int> Indexes = new();

            for (int i = 0; i < List.Count; i++) {
                if (List[i] == Comparison)
                    Indexes.Add(i);
            }

            return Indexes;
        }

        public static List<int> IndexesOf<T>(this List<T> List, Func<T, bool> Predicate)
        {
            List<int> Indexes = new();

            for (int i = 0; i < List.Count; i++) {
                if (Predicate(List[i]))
                    Indexes.Add(i);
            }

            return Indexes;
        }
    }
}