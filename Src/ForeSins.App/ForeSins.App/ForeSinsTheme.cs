using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App
{
    public class ForeSinsTheme
    {
        public const string White = "#FFF";
        public const string MainRed = "#BF406D";
        public const string MainGreen = "#4DB258";
        public const string MainBlue = "#40A9BF";

        public static MudTheme MudTheme => new()
        {
            Palette = new Palette()
            {
                Primary = MainRed,
                PrimaryContrastText = Colors.Shades.White,
                Secondary = MainGreen,
                Tertiary = MainBlue,
                AppbarBackground = Colors.Red.Default,
            }
        };
    }
}