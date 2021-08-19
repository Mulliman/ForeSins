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
            if(score == 0)
            {
                return "E";
            }

            if(score > 0)
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
    }
}
