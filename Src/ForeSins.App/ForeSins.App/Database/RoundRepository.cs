using Blazor.IndexedDB.WebAssembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Database
{
    public class RoundRepository
    {
        public IIndexedDbFactory DbFactory { get; }

        public RoundRepository(IIndexedDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public async Task SaveRound(Round round)
        {
            var existingItem = await GetRound(round.Id);
            Console.WriteLine("SaveRound GetRound");

            if (existingItem != null)
            {
                await UpdateRound(round);
            }
            else
            {
                await AddRound(round);
            }
        }

        public async Task AddRound(Round round)
        {
            Console.WriteLine("AddRound pre");

            using (var db = await DbFactory.Create<ContextDb>())
            {
                Console.WriteLine("AddRound");
                db.Rounds.Add(round);
                await db.SaveChanges();

                Console.WriteLine("AddRound - saved");
            }
        }

        public async Task UpdateRound(Round round)
        {
            Console.WriteLine("UpdateRound pre");

            using (var db = await DbFactory.Create<ContextDb>())
            {
                Console.WriteLine("UpdateRound");
                var record = db.Rounds.Single(x => x.Id == round.Id);
                
                record.CourseHandicap = round.CourseHandicap;
                record.Date = round.Date;
                record.HandicapIndex = round.HandicapIndex;
                record.ResultToHandicap = round.ResultToHandicap;
                record.ResultToPar = round.ResultToPar;
                record.ScrappyDoubles = round.ScrappyDoubles;
                record.ShockingChips = round.ShockingChips;
                record.SickeningYips = round.SickeningYips;
                record.SplashTroubles = round.SplashTroubles;
                record.SquanderedPositions = round.SquanderedPositions;
                record.StupidDecisions = round.StupidDecisions;

                await db.SaveChanges();
            }
        }

        public async Task<List<Round>> GetRounds()
        {
            using (var db = await DbFactory.Create<ContextDb>())
            {
                return db.Rounds.ToList();
            }
        }

        public async Task<Round> GetRound(Guid id)
        {
            using (var db = await DbFactory.Create<ContextDb>())
            {
                return db.Rounds.FirstOrDefault(x => x.Id == id);
            }
        }

        public async Task DeleteRound(Guid id)
        {
            using (var db = await DbFactory.Create<ContextDb>())
            {
                var item = db.Rounds.First(x => x.Id == id);
                db.Rounds.Remove(item);

                await db.SaveChanges();
            }
        }
    }
}