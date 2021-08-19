using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App
{
    public class Round
    {
        public DateTime Date { get; set; }

        public uint SickeningYips { get; set; }

        public uint ShockingChips { get; set; }

        public uint SplashTroubles { get; set; }

        public uint ScrappyDoubles { get; set; }

        public uint SquanderedPositions { get; set; }

        public uint StupidDecisions { get; set; }

        public uint Sins => SickeningYips + ShockingChips + SplashTroubles + ScrappyDoubles + SquanderedPositions + StupidDecisions;

        public int Handicap { get; set; }

        public int ResultToPar { get; set; }

        public int ResultToHandicap { get; set; }
    }
}