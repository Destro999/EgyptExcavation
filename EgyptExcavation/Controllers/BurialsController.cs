using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgyptExcavation.Models;
using EgyptExcavation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace EgyptExcavation 
{
    public class BurialsController : Controller
    {
        // Connect to Burials, Biological Samples, File Uploads
        private readonly EgyptContext _context;
        private readonly FileUploadsContext fileCtx;

        public BurialsController(EgyptContext context, FileUploadsContext fctx)
        {
            _context = context;
            fileCtx = fctx;
        }


        // GET: Burials
        // Returns Burials view. Includes pagination, filters, all the info that the cards need
        public IActionResult Index(string filterId, int pageNum = 0)
        {
            ViewBag.NavBar = "Browse";
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

            // pagination
            var skipNum = pageNum > 0 ? pageNum - 1 : pageNum;
            var burials = query.OrderByDescending(x => x.HasPhoto).Skip((skipNum) * pageSize).Take(pageSize).ToList();

            // put the data in a view model
            BrowseViewModel browseViewModel = new BrowseViewModel
            {
                Burials = burials,
                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    // Takes count from filtered query instead of all items in database
                    TotalNumItems = query.Count()
                }
            };
            return View(browseViewModel);
        }

        // Creates the filter string for Burials index
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string newId = string.Join('-', filter);
            return RedirectToAction("Index", new { filterId = newId }); 
        }


        // GET: Burials/Details/5
        // Pull up the details for a burial. Includes links to file uploads and biological samples.
        public async Task<IActionResult> Details(int? id) 
        {
            ViewBag.NavBar = "Browse";

            if (id == null)
            {
                return NotFound();
            }

            var burial = _context.Burial
                .FirstOrDefault(m => m.BurialIdInt == id);
            if (burial == null)
            {
                return NotFound();
            }

            var samples = _context.BiologicalSample.Where(s => s.BurialId == burial.BurialId).ToList();
            ViewBag.Samples = samples;

            var uploads = fileCtx.Files.Where(t => t.BurialId == burial.BurialId).Select(x => x.DocumentId).ToList();
            ViewBag.Uploads = uploads;

            return View(burial);
        }

        // GET: Burials/Create
        // Create new burial record. Takes user to form
        [Authorize(Policy = "writepolicy")]
        public IActionResult Create()
        {
            ViewBag.NavBar = "Browse";

            return View();
        }

        // POST: Burials/Create
        // Get here from the form. Add the new burial to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Create([Bind("BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemainsMeters,LengthOfRemainsCentimeters,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,SexMethod,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForamanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,SampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,AgeMethod,AgeCode,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,Gamous,BurialIcon,BurialIcon2,BurialPreservation")] Burial burial)
        {
            ViewBag.NavBar = "Browse";

            if (ModelState.IsValid)
            {
                _context.Add(burial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(burial);
        }

        // GET: Burials/Edit/5
        // Edit form for an existing burial. Auto-populates all the necessary fields
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.NavBar = "Browse";

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
        // Save edits to a burial
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Edit(int id, [Bind("BurialIdInt,BurialId,BurialLocationNs,BurialLocationEw,LowPairNs,HighPairNs,LowPairEw,HighPairEw,BurialSubplot,BurialDepth,SouthToHead,SouthToFeet,WestToHead,WestToFeet,BurialSituation,LengthOfRemainsMeters,LengthOfRemainsCentimeters,BurialNumber,SampleNumber,GenderGe,GeFunctionTotal,GenderBodyCol,SexMethod,BasilarSuture,VentralArc,SubpubicAngle,SciaticNotch,PubicBone,PreaurSulcus,MedialIpRamus,DorsalPitting,ForamanMagnum,FemurHead,HumerusHead,Osteophytosis,PubicSymphysis,FemurLength,HumerusLength,TibiaLength,Robust,SupraorbitalRidges,OrbitEdge,ParietalBossing,Gonian,NuchalCrest,ZygomaticCrest,CranialSuture,MaximumCranialLength,MaximumCranialBreadth,BasionBregmaHeight,BasionNasion,BasionProsthionLength,BizygomaticDiameter,NasionProsthion,MaximumNasalBreadth,InterorbitalBreadth,ArtifactsDescription,HairColor,PreservationIndex,SampleTaken,HairTaken,SoftTissueTaken,BoneTaken,ToothTaken,TextileTaken,DescriptionOfTaken,ArtifactFound,EstimateAge,AgeMethod,AgeCode,EstimateLivingStature,ToothAttrition,ToothEruption,PathologyAnomalies,EpiphysealUnion,YearFound,MonthFound,DayFound,HeadDirection,Gamous,BurialIcon,BurialIcon2,BurialPreservation")] Burial burial)
        {
            ViewBag.NavBar = "Browse";
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
        // Requires admin priveleges. Asks user if they really want to delete
        [Authorize(Policy = "adminpolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.NavBar = "Browse";
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
        // Required admin priveleges. Deletes record
        [Authorize(Policy = "adminpolicy")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.NavBar = "Browse";
            var burial = await _context.Burial.FindAsync(id);
            _context.Burial.Remove(burial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Helper function to return if a burial exists in the database
        private bool BurialExists(int id)
        {
            ViewBag.NavBar = "Browse";
            return _context.Burial.Any(e => e.BurialIdInt == id);
        }
    }
}
