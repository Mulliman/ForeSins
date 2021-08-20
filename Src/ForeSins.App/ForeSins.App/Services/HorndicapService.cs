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
            var orderedRounds = rounds.OrderByDescending(r => r.Date);

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

        public SixSixSix CalculateSixSixSix(List<Round> rounds)
        {
            var orderedRounds = rounds.OrderByDescending(r => r.Date);

            var mostRecent6 = orderedRounds.Take(6);
            var last6Months = orderedRounds.Where(r => r.Date > DateTime.Now.AddMonths(-6));
            var last6Years = orderedRounds.Where(r => r.Date > DateTime.Now.AddYears(-6));

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
    }
}