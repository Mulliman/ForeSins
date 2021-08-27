using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Helpers
{
    public static class NumberExtensions
    {
        public static string ToZeroDot(this uint num)
        {
            if(num == 0)
            {
                return ".";
            }

            return num.ToString();
        }
    }
}