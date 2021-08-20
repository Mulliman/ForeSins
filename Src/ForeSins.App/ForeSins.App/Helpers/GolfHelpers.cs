using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Helpers
{
    public static class GolfHelpers
    {
        public static string FormatScore(this int score)
        {
            if (score == 0)
            {
                return "E";
            }

            if (score > 0)
            {
                return $"+{score}";
            }

            return score.ToString();
        }

        public static string GetScoreClass(this int score)
        {
            if (score == 0)
            {
                return "score-level-par";
            }

            if (score > 0)
            {
                return "score-over-par";
            }

            return "score-under-par";
        }

        public static string GetGradeClass(this Grades grade)
        {
            return Enum.GetName(grade).ToLower();
        }

        public static string GetGradeColour(this Grades grade)
        {
            return grade switch
            {
                Grades.G => "gold",
                Grades.A => "gold",
                Grades.B => "green",
                Grades.C => "blue",
                Grades.D => "black",
                Grades.S => "red",
                _ => string.Empty
            };
        }

        public static string GetSinClass(this Sins sin)
        {
            return sin switch
            {
                Sins.ScrappyDoubles => "double",
                Sins.SplashTroubles => "trouble",
                Sins.ShockingChips => "chips",
                Sins.SickeningYips => "yips",
                Sins.SquanderedPositions => "position",
                Sins.StupidDecisions => "decision",
                _ => string.Empty
            };
        }

        public static string GetSinWord(this Sins sin)
        {
            return sin switch
            {
                Sins.ScrappyDoubles => "Scrappy Doubles",
                Sins.SplashTroubles => "Splash Troubles",
                Sins.ShockingChips => "Shocking Chips",
                Sins.SickeningYips => "Sickening Yips",
                Sins.SquanderedPositions => "Squandered Positions",
                Sins.StupidDecisions => "Stupid Decisions",
                _ => string.Empty
            };
        }
    }
}