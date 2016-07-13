using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Utils
{
    public static class StringExtensions
    {

        public static string Limit(this string str, int characterCount)
        {
            return str.Length <= characterCount ? str : str.Substring(0, characterCount).TrimEnd(' ');
        }

        public static string LimitWithElipses(this string str, int characterCount)
        {
            if (characterCount < 5) return str.Limit(characterCount);

            if (str.Length <= (characterCount - 3)) return str;
            return str.Substring(0, characterCount - 3) + "...";
        }

        public static string LimitWithElipsesOnWordBoundary(this string str, int characterCount)
        {
            if (characterCount < 5) return str.Limit(characterCount);

            if (str.Length <= characterCount - 3) return str;

            var lastspace = str.Substring(0, characterCount - 3).LastIndexOf(' ');

            if (lastspace > 0 && lastspace > characterCount - 10) return str.Substring(0, lastspace) + "...";
            return str.Substring(0, characterCount - 3) + "...";
        }
    }
}
