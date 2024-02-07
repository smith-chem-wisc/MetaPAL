using MetaPAL.Data;
using Microsoft.AspNetCore.Mvc;
using Readers;

namespace MetaPAL.Models
{
    public class HelperFunctions : Controller
    {
        private readonly ApplicationDbContext _context;

        public HelperFunctions(ApplicationDbContext context)
        {
            _context = context;
        }

        //POST: Push matches and scans to database with a single button
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PushMatchesAndScansToDatabase(string matchesPath, string scanPath)
        {
            if (ModelState.IsValid)
            {
                //get matches from file
                var spectrumMatches =
                    SpectrumMatchTsvReader.ReadTsv(Path.Combine(matchesPath), out _)
                        .Where(x => !x.Accession.Contains("DECOY") && !x.Accession.Contains("|")) //string input was failing to parse (not sure why but i assume it's the | character)
                        .Select(x => SpectrumMatch.FromSpectrumMatchTsv(x));

                //get scans from file
                var msDataFile =
                    Readers.MsDataFileReader.GetDataFile(Path.Combine(scanPath))
                        .GetMsDataScans()
                        .Select(x => MsDataScanModel.GetModelFromMsDataScan(x));

                //match matches to scans
                foreach (var match in spectrumMatches)
                {
                    var matchedScan = msDataFile.FirstOrDefault(x => x.ScanNumber == match.Ms2ScanNumber);

                    if (matchedScan == null)
                    {
                        continue;
                    }

                    Tuple<SpectrumMatch, MsDataScanModel> bothScanSpectrumMatch = 
                        new Tuple<SpectrumMatch, MsDataScanModel>(match, matchedScan);

                    match.ScanId = matchedScan.Id;
                    _context.Add(match);
                    _context.Add(matchedScan);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction();
            }
            return View(matchesPath);
        }
    }
}
