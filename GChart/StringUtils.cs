using System;
using System.Text.RegularExpressions;

namespace FlugleCharts
{
    internal static class StringUtils
    {
        /// Like linq take - takes the first x characters
        public static string Take(this string theString, int count, bool ellipsis = false)
        {
            int lengthToTake = Math.Min(count, theString.Length);
            var cutDownString = theString.Substring(0, lengthToTake);

            if (ellipsis && lengthToTake < theString.Length)
                cutDownString += "...";

            return cutDownString;
        }

        //like linq skip - skips the first x characters and returns the remaining string
        public static string Skip(this string theString, int count)
        {
            int startIndex = Math.Min(count, theString.Length);
            var cutDownString = theString.Substring(startIndex - 1);

            return cutDownString;
        }

        // "a string".IsNullOrEmpty() beats string.IsNullOrEmpty("a string")
        public static bool IsNullOrEmpty(this string theString)
        {
            return string.IsNullOrEmpty(theString);
        }

        //not so sure about this one -
        //"a string {0}".Format("blah") vs string.Format("a string {0}", "blah")
        public static string With(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static bool Match(this string value, string pattern)
        {
            return Regex.IsMatch(value, pattern);
        }

    }
}
