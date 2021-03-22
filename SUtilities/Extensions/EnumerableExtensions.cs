using System;
using System.Collections.Generic;

namespace STools.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool AddUnique<T>(this IList<T> List, T newItem)
            where T : IEquatable<T>
        {
            foreach (T item in List)
            {
                if (item.Equals(newItem))
                    return false;
            }

            List.Add(newItem);
            return true;
        }
    }
}