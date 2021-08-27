namespace ForeSins.App.Models
{
    public class SixSixSix
    {
        public Horndicap Last6Rounds { get; set; }

        public Horndicap Last6Months { get; set; }

        public Horndicap Last6Years { get; set; }
    }

    public class SixSixSixSins
    {
        public SinAverages Last6Rounds { get; set; }

        public SinAverages Last6Months { get; set; }

        public SinAverages Last6Years { get; set; }
    }

    public class SinAverages : ISinsAverages
    {
        public double SickeningYips { get; set; }

        public double ShockingChips { get; set; }

        public double SplashTroubles { get; set; }

        public double ScrappyDoubles { get; set; }

        public double SquanderedPositions { get; set; }

        public double StupidDecisions { get; set; }
    }
}