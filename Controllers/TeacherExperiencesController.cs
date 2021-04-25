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
    public class TeacherExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherExperiencesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherExperiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherExperiences.Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherExperiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherExperience = await _context.TeacherExperiences
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherExperience == null)
            {
                return NotFound();
            }

            return View(teacherExperience);
        }

        // GET: TeacherExperiences/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers.Where(t => t.Is_Filled_Experience == false), "Id", "Surname");
            return View();
        }

        // POST: TeacherExperiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExperienceTitle,Duration,TeacherId")] TeacherExperience teacherExperience)
        {
            if (ModelState.IsValid)
            {
                //teacherExperience.Teacher.Is_Filled_Experience = true;
                _context.Add(teacherExperience);
                var teacher = _context.Teachers.Find(teacherExperience.TeacherId);
                teacher.Is_Filled_Experience = true;
                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherExperience.TeacherId);
            return View(teacherExperience);
        }

        // GET: TeacherExperiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherExperience = await _context.TeacherExperiences.FindAsync(id);
            if (teacherExperience == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherExperience.TeacherId);
            return View(teacherExperience);
        }

        // POST: TeacherExperiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExperienceTitle,Duration,TeacherId")] TeacherExperience teacherExperience)
        {
            if (id != teacherExperience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherExperience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExperienceExists(teacherExperience.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherExperience.TeacherId);
            return View(teacherExperience);
        }

        // GET: TeacherExperiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherExperience = await _context.TeacherExperiences
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherExperience == null)
            {
                return NotFound();
            }

            return View(teacherExperience);
        }

        // POST: TeacherExperiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherExperience = await _context.TeacherExperiences.FindAsync(id);
            _context.TeacherExperiences.Remove(teacherExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExperienceExists(int id)
        {
            return _context.TeacherExperiences.Any(e => e.Id == id);
        }
    }
}
