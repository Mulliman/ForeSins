using ForeSins.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Services
{
    public class HorndicapService
    {
        private readonly Grader _grader;

        public HorndicapService(Grader grader)
        {
            _grader = grader;
        }

        public Horndicap CalculateHorndicap(List<Round> rounds)
        {
            if (rounds == null || !rounds.Any())
            {
                return null;
            }

            var orderedRounds = new List<Round>(rounds.OrderByDescending(r => r.Date));

            var mostRecent6 = orderedRounds.Take(6);
            var mostRecent12 = orderedRounds.Take(12);
            var mostRecent18 = orderedRounds.Take(18);

            var r6 = mostRecent6.Average(r => Convert.ToInt32(r.Sins));
            var r12 = mostRecent12.Average(r => Convert.ToInt32(r.Sins));
            var r18 = mostRecent18.Average(r => Convert.ToInt32(r.Sins));

            // Weighted on most recent rounds.
            var sindex = (r6 * 0.6) + (r12 * 0.3) + (r18 * 0.1);

            var grade = _grader.Grade(sindex);

            return new Horndicap
            {
                Grade = grade,
                Sindex = sindex
            };
        }

        public IEnumerable<Horndicap> CalculateHorndicapHistory(List<Round> rounds)
        {
            var remainingRounds = new List<Round>(rounds.OrderBy(x => x.Date));
            var list = new List<Horndicap>();

            while (remainingRounds.Count != 0)
            {
                list.Add(CalculateHorndicap(remainingRounds));

                remainingRounds.RemoveAt(remainingRounds.Count - 1);
            }

            list.Reverse();

            return list;
        }

        public SixSixSix CalculateSixSixSix(List<Round> rounds)
        {
            var orderedRounds = new List<Round>(rounds.OrderByDescending(r => r.Date));

            var mostRecent6 = new List<Round>(orderedRounds.Take(6));
            var last6Months = new List<Round>(orderedRounds.Where(r => r.Date > DateTime.Now.AddMonths(-6)));
            var last6Years = new List<Round>(orderedRounds.Where(r => r.Date > DateTime.Now.AddYears(-6)));

            var last6MonthsAverage = last6Months.Average(r => Convert.ToInt32(r.Sins));
            var last6RoundsAverage = mostRecent6.Average(r => Convert.ToInt32(r.Sins));
            var last6YearsAverage = last6Years.Average(r => Convert.ToInt32(r.Sins));

            return new SixSixSix
            {
                Last6Months = new Horndicap { Sindex = last6MonthsAverage, Grade = _grader.Grade(last6MonthsAverage) },
                Last6Rounds = new Horndicap { Sindex = last6RoundsAverage, Grade = _grader.Grade(last6RoundsAverage) },
                Last6Years = new Horndicap { Sindex = last6YearsAverage, Grade = _grader.Grade(last6YearsAverage) }
            };
        }

        public SinAverages CalculateTotals(List<Round> rounds)
        {
            return new SinAverages
            {
                ScrappyDoubles = rounds.Sum(r => r.ScrappyDoubles),
                ShockingChips = rounds.Sum(r => r.ShockingChips),
                SickeningYips = rounds.Sum(r => r.SickeningYips),
                SplashTroubles =rounds.Sum(r => r.SplashTroubles),
                SquanderedPositions =rounds.Sum(r => r.SquanderedPositions),
                StupidDecisions = rounds.Sum(r => r.StupidDecisions)
            };
        }

        public SinAverages CreateVsAverages(ISinsAverages olderAverages, ISinsAverages newerAverages)
        {
            return new SinAverages
            {
                ScrappyDoubles = Math.Round(newerAverages.ScrappyDoubles - olderAverages.ScrappyDoubles, 2),
                ShockingChips = Math.Round(newerAverages.ShockingChips - olderAverages.ShockingChips, 2),
                SickeningYips = Math.Round(newerAverages.SickeningYips - olderAverages.SickeningYips, 2),
                SplashTroubles = Math.Round(newerAverages.SplashTroubles - olderAverages.SplashTroubles, 2),
                SquanderedPositions = Math.Round(newerAverages.SquanderedPositions - olderAverages.SquanderedPositions, 2),
                StupidDecisions = Math.Round(newerAverages.StupidDecisions - olderAverages.StupidDecisions, 2)
            };
        }

        public SixSixSixSins CalculateSixSixSixOfSins(List<Round> rounds)
        {
            var orderedRounds = rounds.OrderByDescending(r => r.Date);

            var mostRecent6 = new List<Round>(orderedRounds.Take(6));
            var last6Months = new List<Round>(orderedRounds.Where(r => r.Date > DateTime.Now.AddMonths(-6)));
            var last6Years = new List<Round>(orderedRounds.Where(r => r.Date > DateTime.Now.AddYears(-6)));

            return new SixSixSixSins
            {
                Last6Months = CreateSinAverages(last6Months),
                Last6Rounds = CreateSinAverages(mostRecent6),
                Last6Years = CreateSinAverages(last6Years),
            };
        }

        public static SinAverages CreateSinAverages(List<Round> rounds)
        {
            return new SinAverages
            {
                ScrappyDoubles = Math.Round(rounds.Average(r => r.ScrappyDoubles), 2),
                ShockingChips = Math.Round(rounds.Average(r => r.ShockingChips), 2),
                SickeningYips = Math.Round(rounds.Average(r => r.SickeningYips), 2),
                SplashTroubles = Math.Round(rounds.Average(r => r.SplashTroubles), 2),
                SquanderedPositions = Math.Round(rounds.Average(r => r.SquanderedPositions), 2),
                StupidDecisions = Math.Round(rounds.Average(r => r.StupidDecisions), 2)
            };
        }
    }
}