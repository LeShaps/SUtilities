using System.Collections.Generic;

namespace STools.Extensions
{
    public static class StringExtensions
    {
        public static string ToWordOnly(this string Word)
        {
            string Result = "";

            if (string.IsNullOrEmpty(Word))
                return Word;

            foreach (char c in Word)
            {
                if (char.IsLetter(c))
                    Result += c;
            }

            return Result;
        }

        public static List<string> CutInParts(this string Content, string Separator, int MaxCharacters)
        {
            List<string> Parts = new();
            string CurrentPart = "";

            foreach (string Section in Content.Split(Separator))
            {
                if (CurrentPart.Length + Section.Length + Separator.Length > MaxCharacters) {
                    Parts.Add(CurrentPart.Substring(0, CurrentPart.Length - Separator.Length));
                    CurrentPart = "";
                }
                CurrentPart += Section + Separator;
            }
            Parts.Add(CurrentPart.Substring(0, CurrentPart.Length - Separator.Length));

            return Parts;
        }

        public static bool Contains(this string String, params string[] Contained)
        {
            foreach (string s in Contained) {
                if (!String.Contains(s)) return false;
            }

            return true;
        }

        public static string ReplaceAll(this string ToClean, string Replacement, params string[] ToReplace)
        {
            foreach (string ToRep in ToReplace)
            {
                ToClean = ToClean.Replace(ToRep, Replacement);
            }

            return ToClean;
        }

        public static bool Is(this string Compare, params string[] Comparaisons)
        {
            foreach (string comp in Comparaisons)
            {
                if (Compare == comp)
                    return true;
            }

            return false;
        }
    }
}