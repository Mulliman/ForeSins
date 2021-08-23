using System;

namespace ForeSins.App
{
    public class Round : ISinsScores
    {
        public DateTime? Date { get; set; }

        public uint SickeningYips { get; set; }

        public uint ShockingChips { get; set; }

        public uint SplashTroubles { get; set; }

        public uint ScrappyDoubles { get; set; }

        public uint SquanderedPositions { get; set; }

        public uint StupidDecisions { get; set; }

        public uint Sins => SickeningYips + ShockingChips + SplashTroubles + ScrappyDoubles + SquanderedPositions + StupidDecisions;

        public double HandicapIndex { get; set; }

        public int CourseHandicap { get; set; }

        public int ResultToPar { get; set; }

        public int ResultToHandicap { get; set; }
    }
}