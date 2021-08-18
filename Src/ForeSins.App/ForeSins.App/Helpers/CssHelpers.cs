using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Helpers
{
    public static class CssHelpers
    {
        public static string ToCssClass(this string str)
        {
            return str.ToHypenSeparatedFromPascalCase();
        }
    }
}