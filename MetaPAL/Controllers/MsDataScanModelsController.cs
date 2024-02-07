using BayesianEstimation;
using MassSpectrometry;
using MetaPAL.Data;
using MetaPAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetaPAL.Controllers
{
    public class MsDataScanModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MsDataScanModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MsDataScanModels
        public async Task<IActionResult> Index()
        {
            return _context.MsDataScans != null ?
                        View(await _context.MsDataScans.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MsDataScan'  is null.");
        }

        // GET: MsDataScanModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MsDataScans == null)
            {
                return NotFound();
            }

            var msDataScanModel = await _context.MsDataScans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msDataScanModel == null)
            {
                return NotFound();
            }

            return View(msDataScanModel);
        }

        // GET: MsDataScanModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MsDataScanModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScanNumber,SpectrumRepresentation,MassSpectrumType,MsLevel,MassAnalyzerType,ScanPolarity,ScanStartTime,ScanWindowUpperLimit,ScanWindowLowerLimit,FilterString,TotalIonCurrent,IonInjectionTime,PrecursorScanNumber,SelectedIonMz,ExperimentalPrecursorMonoisotopicMz,IsolationWindowTargetMz,IsolationWindowLowerOffset,IsolationWindowUpperOffset,DissociationMethod,NormalizedCollisionEnergy,SelectedIonChargeStateGuess,SelectedIonIntensity,NativeId")] MsDataScanModel msDataScanModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(msDataScanModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(msDataScanModel);
        }

        // GET: MsDataScanModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MsDataScans == null)
            {
                return NotFound();
            }

            var msDataScanModel = await _context.MsDataScans.FindAsync(id);
            if (msDataScanModel == null)
            {
                return NotFound();
            }
            return View(msDataScanModel);
        }

        // POST: MsDataScanModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScanNumber,SpectrumRepresentation,MassSpectrumType,MsLevel,MassAnalyzerType,ScanPolarity,ScanStartTime,ScanWindowUpperLimit,ScanWindowLowerLimit,FilterString,TotalIonCurrent,IonInjectionTime,PrecursorScanNumber,SelectedIonMz,ExperimentalPrecursorMonoisotopicMz,IsolationWindowTargetMz,IsolationWindowLowerOffset,IsolationWindowUpperOffset,DissociationMethod,NormalizedCollisionEnergy,SelectedIonChargeStateGuess,SelectedIonIntensity,NativeId")] MsDataScanModel msDataScanModel)
        {
            if (id != msDataScanModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(msDataScanModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MsDataScanModelExists(msDataScanModel.Id))
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
            return View(msDataScanModel);
        }

        // GET: MsDataScanModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MsDataScans == null)
            {
                return NotFound();
            }

            var msDataScanModel = await _context.MsDataScans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (msDataScanModel == null)
            {
                return NotFound();
            }

            return View(msDataScanModel);
        }

        // POST: MsDataScanModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MsDataScans == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MsDataScan'  is null.");
            }
            var msDataScanModel = await _context.MsDataScans.FindAsync(id);
            if (msDataScanModel != null)
            {
                _context.MsDataScans.Remove(msDataScanModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MsDataScanModelExists(int id)
        {
            return (_context.MsDataScans?.Any(e => 
                e.Id == id)).GetValueOrDefault();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReadMsDataFile(string path)
        {
            var msDataFile =
                Readers.MsDataFileReader.GetDataFile(Path.Combine(path))
                .GetMsDataScans()
                .Select(x => MsDataScanModel.GetModelFromMsDataScan(x));

            if (ModelState.IsValid)
            {
                _context.MsDataScans.AddRange(msDataFile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(path);
        }
    }
}
