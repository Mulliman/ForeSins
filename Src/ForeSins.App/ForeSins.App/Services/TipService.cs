using ForeSins.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Services
{
    public class TipService
    {
        List<ITipGenerator> _tipGenerators = new List<ITipGenerator>
        {
            new WorseRecentlyTipGenerator(),
            new GameWeaknessTipGenerator(),
            new Last6WorstGenerator()
        };

        public string GetBestTip(SixSixSixSins sins)
        {
            var tips = _tipGenerators.SelectMany(tg => tg.GetTips(sins));
            var bestTip = tips.OrderBy(t => t.Score).LastOrDefault();

            return bestTip?.Text;
        }
    }

    public class TipResult
    {
        public double Score { get; set; }

        public string Text {  get; set; }

        public static TipResult Create(string message, double difference, double multiplier = 1)
        {
            return new TipResult
            {
                Text= message,
                Score= difference * multiplier
            };
        }
    }

    public interface ITipGenerator
    {
        IEnumerable<TipResult> GetTips(SixSixSixSins sins);
    }

    public class WorseRecentlyTipGenerator : ITipGenerator
    {
        private const double Modifier = 1.5;

        public IEnumerable<TipResult> GetTips(SixSixSixSins sins)
        {

            if (sins.Last6Rounds.ShockingChips > sins.Last6Months.ShockingChips + 1)
            {
                var difference = sins.Last6Rounds.ShockingChips - sins.Last6Months.ShockingChips;
                yield return TipResult.Create("Your chipping seems to have gone downhill recently. Practise ensuring you have a consistent low point.", difference, Modifier);
            }

            if (sins.Last6Rounds.SickeningYips > sins.Last6Months.SickeningYips + 1)
            {
                var difference = sins.Last6Rounds.SickeningYips - sins.Last6Months.SickeningYips;
                yield return TipResult.Create("Your putting seems to have gone downhill recently. Focus more on becoming a great lag putter rather than trying to force long putts, even pros miss more than they hole from outside 10ft.", difference, Modifier);
            }

            if (sins.Last6Rounds.ScrappyDoubles > sins.Last6Months.ScrappyDoubles + 1)
            {
                var difference = sins.Last6Rounds.ScrappyDoubles - sins.Last6Months.ScrappyDoubles;
                yield return TipResult.Create("You have been making more doubles recently. Try playing more to the bigger parts of the green.", difference, Modifier);
            }

            if (sins.Last6Rounds.SplashTroubles > sins.Last6Months.SplashTroubles + 1)
            {
                var difference = sins.Last6Rounds.SplashTroubles - sins.Last6Months.SplashTroubles;
                yield return TipResult.Create("You seem to be losing a lot of balls recently. If there are penalty hazards in play, you should be taking the club that reduces the likelihood of finding them.", difference, Modifier);
            }

            if (sins.Last6Rounds.SquanderedPositions > sins.Last6Months.SquanderedPositions + 1)
            {
                var difference = sins.Last6Rounds.SquanderedPositions - sins.Last6Months.SquanderedPositions;
                yield return TipResult.Create("You've been messing up your chances recently. Work on your wedges and make sure you know how to hit the correct yardages.", difference, Modifier);
            }

            if (sins.Last6Rounds.StupidDecisions > sins.Last6Months.StupidDecisions + 1)
            {
                var difference = sins.Last6Rounds.StupidDecisions - sins.Last6Months.StupidDecisions;
                yield return TipResult.Create("Your decision making has been poor recently. The good news is that you are admitting your faults, take 10 extra seconds to think about the shot at hand.", difference, Modifier);
            }
        }
    }

    public class GameWeaknessTipGenerator : ITipGenerator
    {
        private const double Modifier = 1.5;

        public IEnumerable<TipResult> GetTips(SixSixSixSins sins)
        {
            if (sins.Last6Rounds.ShockingChips > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.ShockingChips - sins.Last6Months.ShockingChips - 2;
                yield return TipResult.Create("Your chipping is a weak point in your game. Practise ensuring you have a consistent low point.", difference, Modifier);
            }

            if (sins.Last6Rounds.SickeningYips > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.SickeningYips - sins.Last6Months.SickeningYips - 2;
                yield return TipResult.Create("Your putting is a weak point in your game. Focus more on becoming a great lag putter rather than trying to force long putts, even pros miss more than they hole from outside 10ft.", difference, Modifier);
            }

            if (sins.Last6Rounds.ScrappyDoubles > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.ScrappyDoubles - sins.Last6Months.ScrappyDoubles - 2;
                yield return TipResult.Create("Making bad scores is a weak point in your game. Try playing more to the bigger parts of the green.", difference, Modifier);
            }

            if (sins.Last6Rounds.SplashTroubles > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.SplashTroubles - sins.Last6Months.SplashTroubles - 2;
                yield return TipResult.Create("Losing balls is a weak point in your game. If there are penalty hazards in play, you should be taking the club that reduces the likelihood of finding them.", difference, Modifier);
            }

            if (sins.Last6Rounds.SquanderedPositions > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.SquanderedPositions - sins.Last6Months.SquanderedPositions - 2;
                yield return TipResult.Create("Making bogeys from good positions is a weak point in your game. Work on your wedges and make sure you know how to hit the correct yardages.", difference, Modifier);
            }

            if (sins.Last6Rounds.StupidDecisions > sins.Last6Months.Average + 2)
            {
                var difference = sins.Last6Rounds.StupidDecisions - sins.Last6Months.StupidDecisions - 2;
                yield return TipResult.Create("Your decision making is a weak point in your game. The good news is that you are admitting your faults, take 10 extra seconds to think about the shot at hand.", difference, Modifier);
            }
        }
    }

    public class Last6WorstGenerator : ITipGenerator
    {
        private const double Modifier = 0.1;

        public IEnumerable<TipResult> GetTips(SixSixSixSins sins)
        {
            var tips = new List<TipResult>();

            tips.Add(TipResult.Create("In the last few rounds your chipping has been your weakest part. Practise ensuring you have a consistent low point.", sins.Last6Rounds.ShockingChips, Modifier));
            tips.Add(TipResult.Create("In the last few rounds your putting has been your weakest part. Focus more on becoming a great lag putter rather than trying to force long putts, even pros miss more than they hole from outside 10ft.", sins.Last6Rounds.SickeningYips, Modifier));
            tips.Add(TipResult.Create("In the last few rounds you've lost the most shots to double bogeys. Try playing more to the bigger parts of the green.", sins.Last6Rounds.ScrappyDoubles, Modifier));
            tips.Add(TipResult.Create("In the last few rounds you've dropped shots due to lost balls. If there are penalty hazards in play, you should be taking the club that reduces the likelihood of finding them.", sins.Last6Rounds.SplashTroubles, Modifier));
            tips.Add(TipResult.Create("In the last few rounds you've bogeyed holes despite being in the perfect position. Work on your wedges and make sure you know how to hit the correct yardages.", sins.Last6Rounds.SquanderedPositions, Modifier));
            tips.Add(TipResult.Create("In the last few rounds you've had a weak mental game. The good news is that you are admitting your faults, take 10 extra seconds to think about the shot at hand.", sins.Last6Rounds.StupidDecisions, Modifier));
            
            return new List<TipResult>() { tips.OrderBy(t => t.Score).LastOrDefault() };
        }
    }
}