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
    public class CommentPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CommentPosts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CommentPosts.Include(c => c.ApplicationUser).Include(c => c.Post);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CommentPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentPost = await _context.CommentPosts
                .Include(c => c.ApplicationUser)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentPost == null)
            {
                return NotFound();
            }

            return View(commentPost);
        }

        // GET: CommentPosts/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Email");
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Title");
            return View();
        }

        // POST: CommentPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Enabled,ApplicationUserId,Created_date,PostId")] CommentPost commentPost)
        {
            if (ModelState.IsValid)
            {
                commentPost.ApplicationUser = _context.Users.Find(commentPost.ApplicationUserId);
                _context.Add(commentPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Posts", new { id = commentPost.PostId });
            }
            //ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", commentPost.ApplicationUserId);
            //ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", commentPost.PostId);
            return View(commentPost);
        }

        // GET: CommentPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentPost = await _context.CommentPosts.FindAsync(id);
            if (commentPost == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", commentPost.ApplicationUserId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", commentPost.PostId);
            return View(commentPost);
        }

        // POST: CommentPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Enabled,ApplicationUserId,Created_date,PostId")] CommentPost commentPost)
        {
            if (id != commentPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commentPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentPostExists(commentPost.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", commentPost.ApplicationUserId);
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Id", commentPost.PostId);
            return View(commentPost);
        }

        // GET: CommentPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commentPost = await _context.CommentPosts
                .Include(c => c.ApplicationUser)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commentPost == null)
            {
                return NotFound();
            }

            return View(commentPost);
        }

        // POST: CommentPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commentPost = await _context.CommentPosts.FindAsync(id);
            _context.CommentPosts.Remove(commentPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentPostExists(int id)
        {
            return _context.CommentPosts.Any(e => e.Id == id);
        }
    }
}
