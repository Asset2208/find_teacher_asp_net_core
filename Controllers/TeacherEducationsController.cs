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
    public class TeacherEducationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherEducationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TeacherEducations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TeacherEducations.Include(t => t.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TeacherEducations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEducation = await _context.TeacherEducations
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherEducation == null)
            {
                return NotFound();
            }

            return View(teacherEducation);
        }

        // GET: TeacherEducations/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers.Where(t => t.Is_Filled_Education == false), "Id", "Surname");
            return View();
        }

        // POST: TeacherEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UniversityName,Speciality,Duration,TeacherId")] TeacherEducation teacherEducation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherEducation);
                var teacher = _context.Teachers.Find(teacherEducation.TeacherId);
                teacher.Is_Filled_Education = true;
                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherEducation.TeacherId);
            return View(teacherEducation);
        }

        // GET: TeacherEducations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEducation = await _context.TeacherEducations.FindAsync(id);
            if (teacherEducation == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherEducation.TeacherId);
            return View(teacherEducation);
        }

        // POST: TeacherEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UniversityName,Speciality,Duration,TeacherId")] TeacherEducation teacherEducation)
        {
            if (id != teacherEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherEducation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherEducationExists(teacherEducation.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Surname", teacherEducation.TeacherId);
            return View(teacherEducation);
        }

        // GET: TeacherEducations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEducation = await _context.TeacherEducations
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherEducation == null)
            {
                return NotFound();
            }

            return View(teacherEducation);
        }

        // POST: TeacherEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherEducation = await _context.TeacherEducations.FindAsync(id);
            _context.TeacherEducations.Remove(teacherEducation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherEducationExists(int id)
        {
            return _context.TeacherEducations.Any(e => e.Id == id);
        }
    }
}
