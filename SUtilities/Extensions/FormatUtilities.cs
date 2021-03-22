using System.Globalization;
using System.Linq;

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
            string nbString = nb.ToString(CultureInfo.InvariantCulture);
            string NewString = "";
            if (nbString.Length >= Size)
                return nbString;
            else
            {
                for (int i = 0; i < Size - nbString.Length; i++)
                    NewString += Character;
                NewString += nbString;
                return NewString;
            }
        }

        public static string StandardUppercase(this string ToUp)
        {
            char UppedChar = char.ToUpperInvariant(ToUp[0]);
            string Lowered = ToUp.Skip(1).ToString().ToLowerInvariant();

            return $"{UppedChar}{Lowered}";
        }
    }
}