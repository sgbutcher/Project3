using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project3.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Student.Include(s => s.Advisor).Include(s => s.Bedaprogram).Include(s => s.Goal).Include(s => s.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Student
                .Include(s => s.Advisor)
                .Include(s => s.Bedaprogram)
                .Include(s => s.Goal)
                .Include(s => s.Location)
                .SingleOrDefaultAsync(m => m.StudentID == id);
            var note = _context.Note;
            var notes = await note.Where(m => m.StudentID == id).ToListAsync();
            student.Notes = notes;
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["AdvisorID"] = new SelectList(_context.Advisor, "AdvisorID", "FirstName", "LastName");
            ViewData["BedaprogramID"] = new SelectList(_context.Bedaprogram, "BedaprogramID", "Name");
            ViewData["GoalID"] = new SelectList(_context.Goal, "GoalID", "Name");
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,SID,LastName,FirstName,PhoneNumber,Email,Intake,Registration,GoalID,BedaprogramID,AdvisorID,LocationID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvisorID"] = new SelectList(_context.Advisor, "AdvisorID", "FirstName", student.AdvisorID);
            ViewData["BedaprogramID"] = new SelectList(_context.Bedaprogram, "BedaprogramID", "Name", student.BedaprogramID);
            ViewData["GoalID"] = new SelectList(_context.Goal, "GoalID", "GoalID", student.GoalID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Name", student.LocationID);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["AdvisorID"] = new SelectList(_context.Advisor, "AdvisorID", "FirstName", student.AdvisorID);
            ViewData["BedaprogramID"] = new SelectList(_context.Bedaprogram, "BedaprogramID", "Name", student.BedaprogramID);
            ViewData["GoalID"] = new SelectList(_context.Goal, "GoalID", "GoalID", student.GoalID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Name", student.LocationID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,SID,LastName,FirstName,PhoneNumber,Email,Intake,Registration,GoalID,BedaprogramID,AdvisorID,LocationID")] Student student)
        {
            if (id != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
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
            ViewData["AdvisorID"] = new SelectList(_context.Advisor, "AdvisorID", "FirstName", student.AdvisorID);
            ViewData["BedaprogramID"] = new SelectList(_context.Bedaprogram, "BedaprogramID", "Name", student.BedaprogramID);
            ViewData["GoalID"] = new SelectList(_context.Goal, "GoalID", "GoalID", student.GoalID);
            ViewData["LocationID"] = new SelectList(_context.Location, "LocationID", "Name", student.LocationID);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Advisor)
                .Include(s => s.Bedaprogram)
                .Include(s => s.Goal)
                .Include(s => s.Location)
                .SingleOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.StudentID == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
