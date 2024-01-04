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
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber,
            SortingOptions sortingParameter = SortingOptions.Default)
        {
            // TEMPORARY: remove all spectrum matches from database
            //await Task.Run(() => DataOperations.DataOperations.RemoveAll<SpectrumMatch>(_context));

            //pagination 
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            int pageSize = 50;

            //big switch statement for sorting the database by different parameters
            #region SortingParametersSwitch



            switch (sortingParameter)
            {
                case SortingOptions.Default:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .AsNoTracking(),
                            pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingAmbiguityLevel:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.AmbiguityLevel)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingAmbiguityLevel:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.AmbiguityLevel)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingDeltaScore:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.DeltaScore)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingDeltaScore:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.DeltaScore)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingMassDiffDa:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.MassDiffDa)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingMassDiffDa:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.MassDiffDa)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingMassDiffPpm:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.MassDiffPpm)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingMassDiffPpm:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.MassDiffPpm)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                //todo: fix this
                case SortingOptions.AscendingMatchedFragmentIons:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.MatchedFragmentIons)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));
                //todo:fix this
                case SortingOptions.DescendingMatchedFragmentIons:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.MatchedFragmentIons)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingMissedCleavage:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.MissedCleavage)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingMissedCleavage:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.MissedCleavage)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingMonoisotopicMass:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.MonoisotopicMass)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingMonoisotopicMass:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.MonoisotopicMass)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPEP_QValue:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PEP_QValue)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPEP_QValue:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PEP_QValue)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPEP:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PEP)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPEP:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PEP)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPrecursorCharge:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PrecursorCharge)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPrecursorCharge:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PrecursorCharge)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPrecursorMass:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PrecursorMass)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPrecursorMass:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PrecursorMass)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPrecursorMz:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PrecursorMz)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPrecursorMz:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PrecursorMz)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.Target:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .Where(x => x.DecoyContamTarget == "T")
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.Decoy:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .Where(x => x.DecoyContamTarget == "D")
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.Contaminant:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .Where(x => x.DecoyContamTarget == "C")
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingPrecursorScanNum:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.PrecursorScanNumber)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingPrecursorScanNum:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.PrecursorScanNumber)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingQValue:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.QValue)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingQValue:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.QValue)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingRetentionTime:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.RetentionTime)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingRetentionTime:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.RetentionTime)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingScore:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.Score)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingScore:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.Score)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingSpliceSites:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.SpliceSites)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingSpliceSites:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.SpliceSites)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.AscendingTotalIonCurrent:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderBy(x => x.TotalIonCurrent)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));

                case SortingOptions.DescendingTotalIonCurrent:
                    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
                        .CreateAsync(_context.SpectrumMatch
                                .OrderByDescending(x => x.TotalIonCurrent)
                                .AsNoTracking(), pageNumber ?? 1, pageSize));
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


        //public async Task<IActionResult> Index(string currentFilter, string searchString,
        //    int? pageNumber)
        //{

        //    if (searchString != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    int pageSize = 50;
        //    return View(await DatabasePagination.PaginatedList<SpectrumMatch>
        //        .CreateAsync(_context.SpectrumMatch.AsNoTracking(), pageNumber ?? 1, pageSize));
        //}
    }
}
