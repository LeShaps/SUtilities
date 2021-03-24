using System.Collections.Generic;
using System.Text;
using System;

namespace STools.Extensions
{
    public static class StringExtensions
    {
        public static string ToWordOnly(this string Word)
        {
            StringBuilder Result = new();

            if (string.IsNullOrEmpty(Word)) {
                throw new ArgumentException("The string was null or empty", nameof(Word));
            }

            foreach (char c in Word)
            {
                if (char.IsLetter(c)) {
                    Result.Append(c);
                }
            }

            return $"{Result}";
        }

        public static ICollection<string> CutInParts(this string Content, string Separator, int MaxCharacters)
        {
            List<string> Parts = new();
            StringBuilder CurrentPart = new();

            if (Content is null) {
                throw new ArgumentNullException(nameof(Content));
            } else if (Separator is null) {
                throw new ArgumentNullException(nameof(Separator));
            } else if (MaxCharacters <= 0) {
                throw new ArgumentOutOfRangeException(nameof(MaxCharacters), "Max Characters must be superior to 0");
            }

            foreach (string Section in Content.Split(Separator))
            {
                if (CurrentPart.Length + Section.Length + Separator.Length > MaxCharacters) {
                    Parts.Add(CurrentPart.ToString(0, CurrentPart.Length - Separator.Length));
                    CurrentPart.Clear();
                }
                CurrentPart.Append(Section + Separator);
            }
            Parts.Add(CurrentPart.ToString(0, CurrentPart.Length - Separator.Length));

            return Parts;
        }

        public static bool Contains(this string FullString, params string[] Contained)
        {
            if (FullString is null) {
                throw new ArgumentNullException(nameof(FullString));
            }

            foreach (string s in Contained)
            {
                if (FullString.Contains(s, StringComparison.InvariantCulture)) {
                    continue;
                }
                return false;
            }

            return true;
        }

        public static string ReplaceAll(this string ToClean, string Replacement, params string[] ToReplace)
        {
            if (ToClean is null) {
                throw new ArgumentNullException(nameof(ToClean));
            } else if (Replacement is null) {
                throw new ArgumentNullException(nameof(Replacement));
            }

            foreach (string ToRep in ToReplace)
            {
                ToClean = ToClean.Replace(ToRep, Replacement, StringComparison.InvariantCulture);
            }

            return ToClean;
        }

        public static bool Is(this string Compare, params string[] Comparaisons)
        {
            foreach (string comp in Comparaisons)
            {
                if (Compare == comp) {
                    return true;
                }
            }
            return false;
        }
    }
}