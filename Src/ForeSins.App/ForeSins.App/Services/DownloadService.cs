using BlazorDownloadFile;
using ForeSins.App.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeSins.App.Services
{
    public class DownloadService
    {
        private readonly RoundRepository _repo;
        private readonly IBlazorDownloadFileService _blazorDownloadFileService;

        public DownloadService(RoundRepository repo, IBlazorDownloadFileService blazorDownloadFileService)
        {
            _repo = repo;
            _blazorDownloadFileService = blazorDownloadFileService;
        }

        public async ValueTask<DowloadFileResult> DownloadAllDataAsCsv(string filename)
        {
            var rounds = await _repo.GetRounds();

            var csv = new StringBuilder();

            var header = "Date,Yips,Chips,Trouble,Double,Position,Decision,HandicapIndex,CourseHandicap,Gross,Nett,ID";
            csv.AppendLine(header);

            foreach (var r in rounds)
            {
                var sinData = $"{r.SickeningYips},{r.ShockingChips},{r.SplashTroubles},{r.ScrappyDoubles},{r.SquanderedPositions},{r.StupidDecisions}";
                var line = $"{r.Date?.ToString("dd-MM-yyyy")},{sinData},{r.HandicapIndex},{r.CourseHandicap},{r.ResultToPar},{r.ResultToHandicap},{r.Id}";
                csv.AppendLine(line);
            }

            return await _blazorDownloadFileService.DownloadFileFromText(filename, csv.ToString(), "text/csv");
        }

        public Round GetRoundFromCsv(string csvData)
        {
            if (string.IsNullOrEmpty(csvData)) return null;

            var split = csvData.Split(',');

            if (split.First() == "Date") return null;

            // Date	Yips	Chips	Trouble	Double	Position	Decision	HandicapIndex	CourseHandicap	Gross	Nett	ID

            return new Round
            {
                Date = DateTime.ParseExact(split[0], "dd-MM-yyyy", CultureInfo.InvariantCulture),
                SickeningYips = uint.Parse(split[1]),
                ShockingChips = uint.Parse(split[2]),
                SplashTroubles = uint.Parse(split[3]),
                ScrappyDoubles = uint.Parse(split[4]),
                SquanderedPositions = uint.Parse(split[5]),
                StupidDecisions = uint.Parse(split[6]),
                HandicapIndex = double.Parse(split[7]),
                CourseHandicap = int.Parse(split[8]),
                ResultToPar = int.Parse(split[9]),
                ResultToHandicap = int.Parse(split[10]),
                Id = Guid.Parse(split[11])
            };
        }
    }
}