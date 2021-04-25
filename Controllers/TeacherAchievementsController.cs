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
    public class TeacherAchievementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherAchievementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherAchievements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherAchievements.Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherAchievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAchievement = await _context.TeacherAchievements
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherAchievement == null)
            {
                return NotFound();
            }

            return View(teacherAchievement);
        }

        // GET: TeacherAchievements/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers.Where(t => t.Is_Filled_Achievement == false), "Id", "Surname");
            return View();
        }

        // POST: TeacherAchievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AchievementTitle,Duration,TeacherId")] TeacherAchievement teacherAchievement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherAchievement);
                var teacher = _context.Teachers.Find(teacherAchievement.TeacherId);
                teacher.Is_Filled_Achievement = true;
                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherAchievement.TeacherId);
            return View(teacherAchievement);
        }

        // GET: TeacherAchievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAchievement = await _context.TeacherAchievements.FindAsync(id);
            if (teacherAchievement == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherAchievement.TeacherId);
            return View(teacherAchievement);
        }

        // POST: TeacherAchievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AchievementTitle,Duration,TeacherId")] TeacherAchievement teacherAchievement)
        {
            if (id != teacherAchievement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherAchievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherAchievementExists(teacherAchievement.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherAchievement.TeacherId);
            return View(teacherAchievement);
        }

        // GET: TeacherAchievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherAchievement = await _context.TeacherAchievements
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherAchievement == null)
            {
                return NotFound();
            }

            return View(teacherAchievement);
        }

        // POST: TeacherAchievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherAchievement = await _context.TeacherAchievements.FindAsync(id);
            _context.TeacherAchievements.Remove(teacherAchievement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherAchievementExists(int id)
        {
            return _context.TeacherAchievements.Any(e => e.Id == id);
        }
    }
}
