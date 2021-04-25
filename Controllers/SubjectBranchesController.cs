using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FindTeacher.Data;
using FindTeacher.Models;

namespace FindTeacher.Controllers
{
    public class SubjectBranchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectBranchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectBranches
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubjectBranches.Include(s => s.Subject);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SubjectBranches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBranch = await _context.SubjectBranches
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectBranch == null)
            {
                return NotFound();
            }

            return View(subjectBranch);
        }

        // GET: SubjectBranches/Create
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name");
            return View();
        }

        // POST: SubjectBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SubjectId")] SubjectBranch subjectBranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subjectBranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", subjectBranch.SubjectId);
            return View(subjectBranch);
        }

        // GET: SubjectBranches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBranch = await _context.SubjectBranches.FindAsync(id);
            if (subjectBranch == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", subjectBranch.SubjectId);
            return View(subjectBranch);
        }

        // POST: SubjectBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SubjectId")] SubjectBranch subjectBranch)
        {
            if (id != subjectBranch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectBranch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectBranchExists(subjectBranch.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Name", subjectBranch.SubjectId);
            return View(subjectBranch);
        }

        // GET: SubjectBranches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subjectBranch = await _context.SubjectBranches
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subjectBranch == null)
            {
                return NotFound();
            }

            return View(subjectBranch);
        }

        // POST: SubjectBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subjectBranch = await _context.SubjectBranches.FindAsync(id);
            _context.SubjectBranches.Remove(subjectBranch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectBranchExists(int id)
        {
            return _context.SubjectBranches.Any(e => e.Id == id);
        }
    }
}
