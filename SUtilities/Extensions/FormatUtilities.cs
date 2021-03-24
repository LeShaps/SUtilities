using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace STools.Extensions
{
    public static class FormatUtilities
    {
        /// <summary>
        /// Add characters to the end of the number to get the size you want
        /// </summary>
        /// <param name="nb">Original number</param>
        /// <param name="Character">What character should be used to fill the trailing characters</param>
        /// <param name="Size">Minimum final string size</param>
        /// <returns></returns>
        public static string TrailingCharacters(this int nb, char Character, int Size)
        {
            if (nb <= 0) {
                throw new ArgumentException("Can't trail negative number", nameof(nb));
            }

            string nbString = $"{nb}";
            StringBuilder NewString = new();

            if (nbString.Length >= Size) {
                return nbString;
            }
            else {
                for (int i = 0; i < Size - nbString.Length; i++) {
                    NewString.Append(Character);
                }
                NewString.Append(nbString);
                return $"{NewString}";
            }
        }

        public static string StandardUppercase(this string ToUp)
        {
            if (ToUp is null) {
                throw new ArgumentNullException(nameof(ToUp));
            }

            char UppedChar = char.ToUpperInvariant(ToUp[0]);
#pragma warning disable CA1308 // Normalize strings to uppercase
            string Lowered = string.Join("", ToUp.Skip(1))
                                   .ToLowerInvariant();
#pragma warning restore CA1308 // Normalize strings to uppercase

            return $"{UppedChar}{Lowered}";
        }
    }
}