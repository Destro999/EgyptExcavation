using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgyptExcavation.Models;
using EgyptExcavation.Models.ViewModels;

namespace EgyptExcavation
{
    public class BurialsController : Controller
    {
        private readonly EgyptContext _context;

        public BurialsController(EgyptContext context)
        {
            _context = context;
        }


        // GET: Burials
        // Edited by Jonah to include Pagination
        public IActionResult Index(string filterId, int pageNum = 0)
        {
            int pageSize = 5;

            //filters
            var filters = new Filters(filterId);
            ViewBag.Filters = filters;
            ViewBag.BurialSubplots = _context.Burial.Select(y => y.BurialSubplot).Distinct().ToList();
            ViewBag.Sex = _context.Burial.Select(y => y.GenderBodyCol).Distinct().ToList();
            ViewBag.HairColor = _context.Burial.Select(y => y.HairColor).Distinct().ToList();
            ViewBag.SampleTaken = _context.Burial.Select(y => y.SampleTaken).Distinct().ToList();
            ViewBag.AgeCode = _context.Burial.Select(y => y.AgeCode).Distinct().ToList();
            ViewBag.HeadDirection = _context.Burial.Select(y => y.HeadDirection).Distinct().ToList();
            ViewBag.YearFound = _context.Burial.Select(y => y.YearFound).Distinct().OrderBy(x => x).ToList();

            ViewBag.SexFilterValues = Filters.SexFilterValues;
            ViewBag.HairColorFilterValues = Filters.HairColorFilterValues;
            ViewBag.SampleTakenFilterValues = Filters.SampleTakenFilterValues;
            ViewBag.AgeCodeFilterValues = Filters.AgeCodeFilterValues;
            ViewBag.HeadDirectionFilterValues = Filters.HeadDirectionFilterValues;

            IQueryable<Burial> query = _context.Burial;

            if (filters.HasBurialSubplot)
            {
                query = query.Where(b => b.BurialSubplot == filters.BurialSubplot);
            }
            if (filters.HasSex)
            {
                query = query.Where(b => b.GenderBodyCol == filters.Sex);
            }
            if (filters.HasHairColor)
            {
                query = query.Where(b => b.HairColor == filters.HairColor);
            }
            if (filters.HasSampleTaken)
            {
                query = query.Where(b => b.SampleTaken == filters.SampleTaken);
            }
            if (filters.HasAgeCode)
            {
                query = query.Where(b => b.AgeCode == filters.AgeCode);
            }
            if (filters.HasHeadDirection)
            {
                query = query.Where(b => b.HeadDirection == filters.HeadDirection);
            }
            if (filters.HasYearFound)
            {
                query = query.Where(b => b.YearFound == filters.YearFound);
            }

            var burials = query.OrderByDescending(x => x.HasPhoto).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            




            BrowseViewModel browseViewModel = new BrowseViewModel
            {
                //Burials = _context.Burial.OrderByDescending(x => x.HasPhoto).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList(),
                Burials = burials,
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    // This will need to be adjusted to account for when filters are applied
                    TotalNumItems = query.Count()
                }
            };
            return View(browseViewModel);
        }


        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string newId = string.Join('-', filter);
            return RedirectToAction("Index", new { filterId = newId }); //Might have to adjust "ID" here, not sure if that name is by convention
        }



        //This will be referenced in the BurialFilterViewComponent to return the Burials Index view, but filtered with the form data
        public IActionResult IndexFiltered(int pageNum = 0)
        {
            int pageSize = 5;
            BrowseViewModel browseViewModel = new BrowseViewModel
            {
                Burials = _context.Burial.OrderByDescending(x => x.HasPhoto).Skip((pageNum - 1) * pageSize).Take(pageSize).ToList(),
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    // This will need to be adjusted to account for when filters are applied
                    TotalNumItems = _context.Burial.Count()
                }
            };
            return View("Index");
        }

        // GET: Burials/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial
                .FirstOrDefaultAsync(m => m.BurialIdInt == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // GET: Burials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Burials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemainsMeters,LengthOfRemainsCentimeters,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,SexMethod,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForamanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,SampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,AgeMethod,AgeCode,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,Gamous,BurialIcon,BurialIcon2,BurialPreservation")] Burial burial)
        {

            if (ModelState.IsValid)
            {
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burial);
        }

        // GET: Burials/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial.FindAsync(id);
            if (burial == null)
            {
                return NotFound();
            }
            return View(burial);
        }

        // POST: Burials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BurialIdInt,BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemainsMeters,LengthOfRemainsCentimeters,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,SexMethod,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForamanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,SampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,AgeMethod,AgeCode,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,Gamous,BurialIcon,BurialIcon2,BurialPreservation")] Burial burial)
        {
            if (id != burial.BurialIdInt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(burial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurialExists(burial.BurialIdInt))
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
            return View(burial);
        }

        // GET: Burials/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burial = await _context.Burial
                .FirstOrDefaultAsync(m => m.BurialIdInt == id);
            if (burial == null)
            {
                return NotFound();
            }

            return View(burial);
        }

        // POST: Burials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var burial = await _context.Burial.FindAsync(id);
            _context.Burial.Remove(burial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BurialExists(int id)
        {
            return _context.Burial.Any(e => e.BurialIdInt == id);
        }
    }
}
