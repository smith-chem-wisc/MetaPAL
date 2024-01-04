using BayesianEstimation;
using MathNet.Numerics;
using MetaPAL.Data;
using MetaPAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Readers;

namespace MetaPAL.Controllers
{
    public class SpectrumMatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpectrumMatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpectrumMatches
        public async Task<IActionResult> Index(SortingOptions sortingParameter = SortingOptions.Default)
        {
            // TEMPORARY: remove all spectrum matches from database
            //await Task.Run(() => DataOperations.DataOperations.RemoveAll<SpectrumMatch>(_context));

            //big switch statement for sorting the database by different parameters
            #region SortingParametersSwitch

            switch (sortingParameter)
            {
                case SortingOptions.Default: 
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .ToListAsync());

                case SortingOptions.AscendingAmbiguityLevel:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderBy(x => x.AmbiguityLevel)
                            .ToListAsync());

                case SortingOptions.DescendingAmbiguityLevel:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderByDescending(x => x.MatchedFragmentIons)
                            .ToListAsync());

                case SortingOptions.AscendingDeltaScore:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderBy(x => x.DeltaScore)
                            .ToListAsync());

                case SortingOptions.DescendingDeltaScore:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderByDescending(x => x.DeltaScore)
                            .ToListAsync());

                case SortingOptions.AscendingMassDiffDa:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderBy(x => x.MassDiffDa)
                            .ToListAsync());

                case SortingOptions.DescendingMassDiffDa:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderByDescending(x => x.MassDiffDa)
                            .ToListAsync());

                case SortingOptions.AscendingMassDiffPpm:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderBy(x => x.MassDiffPpm)
                            .ToListAsync());

                case SortingOptions.DescendingMassDiffPpm:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderByDescending(x => x.MassDiffPpm)
                            .ToListAsync());

                case SortingOptions.AscendingMatchedFragmentIons:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderBy(x => x.MatchedFragmentIons)
                            .ToListAsync());

                case SortingOptions.DescendingMatchedFragmentIons:
                    return _context.SpectrumMatch == null ?
                        Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.") :
                        View(await _context.SpectrumMatch
                            .OrderByDescending(x => x.MatchedFragmentIons)
                            .ToListAsync());
            }

            #endregion

            if (_context.SpectrumMatch == null)
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            return View(await _context.SpectrumMatch.ToListAsync());
        }

        // GET: UploadSpectralMatchesForm
        public async Task<IActionResult> UploadSpectralMatchesForm()
        {
            return _context.SpectrumMatch.SingleOrDefault() != null ?
                View() :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }

        //Sorting Enum
#region SortingEnum
        public enum SortingOptions
        {
            Default,
            AscendingMatchedFragmentIons,
            DescendingMatchedFragmentIons,
            AscendingPrecursorScanNum,
            DescendingPrecursorScanNum,
            AscendingPrecursorCharge,
            DescendingPrecursorCharge,
            AscendingPrecursorMz,
            DescendingPrecursorMz,
            AscendingPrecursorMass,
            DescendingPrecursorMass,
            AscendingRetentionTime,
            DescendingRetentionTime,
            AscendingScore,
            DescendingScore,
            AscendingSpectrumMatchCount,
            DescendingSpectrumMatchCount,
            AscendingQValue,
            DescendingQValue,
            AscendingPEP,
            DescendingPEP,
            AscendingPEP_QValue,
            DescendingPEP_QValue,
            AscendingTotalIonCurrent,
            DescendingTotalIonCurrent,
            AscendingDeltaScore,
            DescendingDeltaScore,
            AscendingAmbiguityLevel,
            DescendingAmbiguityLevel,
            AscendingMissedCleavage,
            DescendingMissedCleavage,
            AscendingMonoisotopicMass,
            DescendingMonoisotopicMass,
            AscendingMassDiffDa,
            DescendingMassDiffDa,
            AscendingMassDiffPpm,
            DescendingMassDiffPpm,
            AscendingSpliceSites,
            DescendingSpliceSites,
            Decoy,
            Contaminant,
            Target
        }
#endregion
        // GET: UploadSpectrumMatches
        public async Task<IActionResult> UploadSpectralMatches(string PsmPath)
        {
            if (_context.SpectrumMatch == null)
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            try
            {
                foreach (var psm in SpectrumMatchTsvReader.ReadTsv(PsmPath, out _)
                             .Select(SpectrumMatch.FromSpectrumMatchTsv))
                {
                    _context.Add(psm);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        // GET: ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return _context.SpectrumMatch != null ?
                View() :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }

        // GET: ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string SearchPhrase)
        {
            return _context.SpectrumMatch != null ?
                View(await _context.SpectrumMatch.Where(b =>
                    b.BaseSequence.Contains(SearchPhrase)).ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
        }
        // GET: SpectrumMatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }

            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpectrumMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchedFragmentIons,FullSequence,Ms2ScanNumber,FileNameWithoutExtension,PrecursorScanNum,PrecursorCharge,PrecursorMz,PrecursorMass,RetentionTime,Score,SpectrumMatchCount,Accession,SpectralAngle,QValue,PEP,PEP_QValue,TotalIonCurrent,DeltaScore,Notch,BaseSeq,EssentialSeq,AmbiguityLevel,MissedCleavage,MonoisotopicMass,MassDiffDa,MassDiffPpm,Name,GeneName,OrganismName,IntersectingSequenceVariations,IdentifiedSequenceVariations,SpliceSites,Description,StartAndEndResiduesInParentSequence,PreviousResidue,NextResidue,DecoyContamTarget,QValueNotch")] SpectrumMatch spectrumMatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spectrumMatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch.FindAsync(id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }
            return View(spectrumMatch);
        }

        // POST: SpectrumMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchedFragmentIons,FullSequence,Ms2ScanNumber,FileNameWithoutExtension,PrecursorScanNum,PrecursorCharge,PrecursorMz,PrecursorMass,RetentionTime,Score,SpectrumMatchCount,Accession,SpectralAngle,QValue,PEP,PEP_QValue,TotalIonCurrent,DeltaScore,Notch,BaseSeq,EssentialSeq,AmbiguityLevel,MissedCleavage,MonoisotopicMass,MassDiffDa,MassDiffPpm,Name,GeneName,OrganismName,IntersectingSequenceVariations,IdentifiedSequenceVariations,SpliceSites,Description,StartAndEndResiduesInParentSequence,PreviousResidue,NextResidue,DecoyContamTarget,QValueNotch")] SpectrumMatch spectrumMatch)
        {
            if (id != spectrumMatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spectrumMatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpectrumMatchExists(spectrumMatch.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(spectrumMatch);
        }

        // GET: SpectrumMatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SpectrumMatch == null)
            {
                return NotFound();
            }

            var spectrumMatch = await _context.SpectrumMatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spectrumMatch == null)
            {
                return NotFound();
            }

            return View(spectrumMatch);
        }

        // POST: SpectrumMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SpectrumMatch == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SpectrumMatch'  is null.");
            }
            var spectrumMatch = await _context.SpectrumMatch.FindAsync(id);
            if (spectrumMatch != null)
            {
                _context.SpectrumMatch.Remove(spectrumMatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpectrumMatchExists(int id)
        {
            return (_context.SpectrumMatch?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //POST: ReadPSMTSVFile using the location of the file
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReadPSMTSVFile(string path)
        {
            var spectrumMatches =
                SpectrumMatchTsvReader.ReadTsv(Path.Combine(path), out _)
                    .Where(x => !x.Accession.Contains("DECOY") && !x.Accession.Contains("|")) //string input was failing to parse (not sure why but i assume it's the | character)
                    .Select(x => SpectrumMatch.FromSpectrumMatchTsv(x));

            if (ModelState.IsValid)
            {
                _context.AddRange(spectrumMatches);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(path);
        }

        //Pagination (faster calls to the server)
        [HttpGet]
        public IEnumerable<SpectrumMatch> GetSpectrumMatches(int pageNumber = 1, int pageSize = 50)
        {
            var totalCount = _context.SpectrumMatch.Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var spectrumPerPage = _context.SpectrumMatch
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return spectrumPerPage;
        }

        [HttpGet]
        public IEnumerable<SpectrumMatch> NextPage(int pageNumber = 1, int pageSize = 50)
        {
            var totalCount = _context.SpectrumMatch.Count();

            var totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);

            var spectrumPerPage = _context.SpectrumMatch
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return spectrumPerPage;
        }


        public async Task<IActionResult> Index(string currentFilter, string searchString,
            int? pageNumber)
        {

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 50;
            return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                .CreateAsync(_context.SpectrumMatch.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}
