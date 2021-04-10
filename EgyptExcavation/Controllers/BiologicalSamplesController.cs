﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EgyptExcavation.Models;

namespace EgyptExcavation.Controllers
{
    public class BiologicalSamplesController : Controller
    {
        private readonly EgyptContext _context;

        public BiologicalSamplesController(EgyptContext context)
        {
            _context = context;
        }

        // GET: BiologicalSamples
        public async Task<IActionResult> Index()
        {
            return View(await _context.BiologicalSample.ToListAsync());
        }

        // GET: BiologicalSamples/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSample
                .FirstOrDefaultAsync(m => m.BiologicalId == id);
            if (biologicalSample == null)
            {
                return NotFound();
            }

            return View(biologicalSample);
        }

        // GET: BiologicalSamples/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BiologicalSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiologicalId,RackNumber,BagNumber,BurialId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,ClusterNumber,Date,PreviouslySampled,Notes,Initials,Column17")] BiologicalSample biologicalSample)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biologicalSample);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biologicalSample);
        }

        // GET: BiologicalSamples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSample.FindAsync(id);
            if (biologicalSample == null)
            {
                return NotFound();
            }
            return View(biologicalSample);
        }

        // POST: BiologicalSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiologicalId,RackNumber,BagNumber,BurialId,LowPairNs,HighPairNs,BurialLocationNs,LowPairEw,HighPairEw,BurialLocationEw,BurialSubplot,BurialNumber,ClusterNumber,Date,PreviouslySampled,Notes,Initials,Column17")] BiologicalSample biologicalSample)
        {
            if (id != biologicalSample.BiologicalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biologicalSample);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiologicalSampleExists(biologicalSample.BiologicalId))
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
            return View(biologicalSample);
        }

        // GET: BiologicalSamples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biologicalSample = await _context.BiologicalSample
                .FirstOrDefaultAsync(m => m.BiologicalId == id);
            if (biologicalSample == null)
            {
                return NotFound();
            }

            return View(biologicalSample);
        }

        // POST: BiologicalSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biologicalSample = await _context.BiologicalSample.FindAsync(id);
            _context.BiologicalSample.Remove(biologicalSample);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiologicalSampleExists(int id)
        {
            return _context.BiologicalSample.Any(e => e.BiologicalId == id);
        }
    }
}