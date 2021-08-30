using BlazorDownloadFile;
using ForeSins.App.Database;
using System;
using System.Collections.Generic;
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
    }
}