using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ForeSins.App.Helpers
{
    public static class StringHelpers
    {
        public static string ToCamelCaseFromPascalCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 1)
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }

            return str;
        }

        public static string ToHypenSeparatedFromPascalCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => $"{m.Value[0]}-{char.ToLower(m.Value[1])}").ToLower();
        }
    }
}
