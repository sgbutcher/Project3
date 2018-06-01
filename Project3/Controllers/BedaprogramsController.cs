using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project3.Controllers
{
    [Authorize]
    public class BedaprogramsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BedaprogramsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bedaprograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bedaprogram.ToListAsync());
        }

        // GET: Bedaprograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedaprogram = await _context.Bedaprogram
                .SingleOrDefaultAsync(m => m.BedaprogramID == id);
            if (bedaprogram == null)
            {
                return NotFound();
            }

            return View(bedaprogram);
        }

        // GET: Bedaprograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bedaprograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BedaprogramID,Name")] Bedaprogram bedaprogram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedaprogram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bedaprogram);
        }

        // GET: Bedaprograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedaprogram = await _context.Bedaprogram.SingleOrDefaultAsync(m => m.BedaprogramID == id);
            if (bedaprogram == null)
            {
                return NotFound();
            }
            return View(bedaprogram);
        }

        // POST: Bedaprograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BedaprogramID,Name")] Bedaprogram bedaprogram)
        {
            if (id != bedaprogram.BedaprogramID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bedaprogram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedaprogramExists(bedaprogram.BedaprogramID))
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
            return View(bedaprogram);
        }

        // GET: Bedaprograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedaprogram = await _context.Bedaprogram
                .SingleOrDefaultAsync(m => m.BedaprogramID == id);
            if (bedaprogram == null)
            {
                return NotFound();
            }

            return View(bedaprogram);
        }

        // POST: Bedaprograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bedaprogram = await _context.Bedaprogram.SingleOrDefaultAsync(m => m.BedaprogramID == id);
            _context.Bedaprogram.Remove(bedaprogram);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedaprogramExists(int id)
        {
            return _context.Bedaprogram.Any(e => e.BedaprogramID == id);
        }
    }
}
