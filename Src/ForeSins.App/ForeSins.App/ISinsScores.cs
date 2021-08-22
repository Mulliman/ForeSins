namespace ForeSins.App
{
    public interface ISinsScores
    {
        uint SickeningYips { get; set; }

        uint ShockingChips { get; set; }

        uint SplashTroubles { get; set; }

        uint ScrappyDoubles { get; set; }

        uint SquanderedPositions { get; set; }

        uint StupidDecisions { get; set; }
    }

    public class SinScore
    {
        public Sins Sin { get; set; }

        public uint Value { get; set; }
    }
}