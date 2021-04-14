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
    public class SystemFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemFeedbacks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SystemFeedbacks.Include(s => s.SystemFeedbackCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SystemFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedback = await _context.SystemFeedbacks
                .Include(s => s.SystemFeedbackCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemFeedback == null)
            {
                return NotFound();
            }

            return View(systemFeedback);
        }

        // GET: SystemFeedbacks/Create
        public IActionResult Create()
        {
            ViewData["SystemFeedbackCategoryId"] = new SelectList(_context.SystemFeedbackCategories, "Id", "Name");
            return View();
        }

        // POST: SystemFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserFullName,UserEmail,Message,SystemFeedbackCategoryId")] SystemFeedback systemFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SystemFeedbackCategoryId"] = new SelectList(_context.SystemFeedbackCategories, "Id", "Id", systemFeedback.SystemFeedbackCategoryId);
            return View(systemFeedback);
        }

        // GET: SystemFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedback = await _context.SystemFeedbacks.FindAsync(id);
            if (systemFeedback == null)
            {
                return NotFound();
            }
            ViewData["SystemFeedbackCategoryId"] = new SelectList(_context.SystemFeedbackCategories, "Id", "Id", systemFeedback.SystemFeedbackCategoryId);
            return View(systemFeedback);
        }

        // POST: SystemFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserFullName,UserEmail,Message,SystemFeedbackCategoryId")] SystemFeedback systemFeedback)
        {
            if (id != systemFeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemFeedbackExists(systemFeedback.Id))
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
            ViewData["SystemFeedbackCategoryId"] = new SelectList(_context.SystemFeedbackCategories, "Id", "Id", systemFeedback.SystemFeedbackCategoryId);
            return View(systemFeedback);
        }

        // GET: SystemFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedback = await _context.SystemFeedbacks
                .Include(s => s.SystemFeedbackCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemFeedback == null)
            {
                return NotFound();
            }

            return View(systemFeedback);
        }

        // POST: SystemFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemFeedback = await _context.SystemFeedbacks.FindAsync(id);
            _context.SystemFeedbacks.Remove(systemFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemFeedbackExists(int id)
        {
            return _context.SystemFeedbacks.Any(e => e.Id == id);
        }
    }
}
