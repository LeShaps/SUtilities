using System;
using System.Collections.Generic;
using System.Linq;

namespace STools.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool AddUnique<T>(this IList<T> List, T newItem)
            where T : IEquatable<T>
        {
            if (List is null) {
                throw new ArgumentNullException(nameof(List), "List can't be null");
            }

            if (List.Contains(newItem)) {
                return false;
            }

            List.Add(newItem);
            return true;
        }
    }
}