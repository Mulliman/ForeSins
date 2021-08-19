using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App
{
    public class Fakes
    {
        public static List<Round> Rounds = new List<Round>
        {
            new Round
            {
                Date = DateTime.Now.AddDays(-1),
                Handicap = 2,
                ResultToHandicap = 4,
                ResultToPar = 6,
                ScrappyDoubles = 1,
                ShockingChips = 2,
                SickeningYips = 0,
                SplashTroubles = 1,
                SquanderedPositions = 3,
                StupidDecisions = 1,
            },
            new Round
            {
                Date = DateTime.Now.AddDays(-10),
                Handicap = 2,
                ResultToHandicap = 7,
                ResultToPar = 9,
                ScrappyDoubles = 1,
                ShockingChips = 0,
                SickeningYips = 0,
                SplashTroubles = 0,
                SquanderedPositions = 0,
                StupidDecisions = 0,
            },
            new Round
            {
                Date = DateTime.Now.AddDays(-20),
                Handicap = 2,
                ResultToHandicap = -4,
                ResultToPar = -2,
                ScrappyDoubles = 1,
                ShockingChips = 2,
                SickeningYips = 0,
                SplashTroubles = 0,
                SquanderedPositions = 0,
                StupidDecisions = 0,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-40),
                Handicap = 2,
                ResultToHandicap = -2,
                ResultToPar = 0,
                ScrappyDoubles = 1,
                ShockingChips = 2,
                SickeningYips = 0,
                SplashTroubles = 1,
                SquanderedPositions = 3,
                StupidDecisions = 1,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-60),
                Handicap = 2,
                ResultToHandicap = 2,
                ResultToPar = 4,
                ScrappyDoubles = 1,
                ShockingChips = 1,
                SickeningYips = 0,
                SplashTroubles = 1,
                SquanderedPositions = 0,
                StupidDecisions = 1,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-100),
                Handicap = 2,
                ResultToHandicap = 12,
                ResultToPar = 14,
                ScrappyDoubles = 4,
                ShockingChips = 2,
                SickeningYips = 3,
                SplashTroubles = 4,
                SquanderedPositions = 3,
                StupidDecisions = 3,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-120),
                Handicap = 2,
                ResultToHandicap = 4,
                ResultToPar = 6,
                ScrappyDoubles = 1,
                ShockingChips = 2,
                SickeningYips = 0,
                SplashTroubles = 1,
                SquanderedPositions = 3,
                StupidDecisions = 1,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-180),
                Handicap = 2,
                ResultToHandicap = 8,
                ResultToPar = 10,
                ScrappyDoubles = 1,
                ShockingChips = 2,
                SickeningYips = 0,
                SplashTroubles = 1,
                SquanderedPositions = 3,
                StupidDecisions = 1,
            },
new Round
            {
                Date = DateTime.Now.AddDays(-260),
                Handicap = 2,
                ResultToHandicap = 14,
                ResultToPar = 16,
                ScrappyDoubles = 10,
                ShockingChips = 2,
                SickeningYips = 4,
                SplashTroubles = 5,
                SquanderedPositions = 3,
                StupidDecisions = 1,
            },

        };
    }
}
