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
    public class SystemFeedbackCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SystemFeedbackCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SystemFeedbackCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.SystemFeedbackCategories.ToListAsync());
        }

        // GET: SystemFeedbackCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedbackCategory = await _context.SystemFeedbackCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemFeedbackCategory == null)
            {
                return NotFound();
            }

            return View(systemFeedbackCategory);
        }

        // GET: SystemFeedbackCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemFeedbackCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SystemFeedbackCategory systemFeedbackCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemFeedbackCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(systemFeedbackCategory);
        }

        // GET: SystemFeedbackCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedbackCategory = await _context.SystemFeedbackCategories.FindAsync(id);
            if (systemFeedbackCategory == null)
            {
                return NotFound();
            }
            return View(systemFeedbackCategory);
        }

        // POST: SystemFeedbackCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SystemFeedbackCategory systemFeedbackCategory)
        {
            if (id != systemFeedbackCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(systemFeedbackCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SystemFeedbackCategoryExists(systemFeedbackCategory.Id))
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
            return View(systemFeedbackCategory);
        }

        // GET: SystemFeedbackCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemFeedbackCategory = await _context.SystemFeedbackCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (systemFeedbackCategory == null)
            {
                return NotFound();
            }

            return View(systemFeedbackCategory);
        }

        // POST: SystemFeedbackCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var systemFeedbackCategory = await _context.SystemFeedbackCategories.FindAsync(id);
            _context.SystemFeedbackCategories.Remove(systemFeedbackCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SystemFeedbackCategoryExists(int id)
        {
            return _context.SystemFeedbackCategories.Any(e => e.Id == id);
        }
    }
}
