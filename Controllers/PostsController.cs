using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FindTeacher.Data;
using FindTeacher.Models;
using Microsoft.AspNetCore.Authorization;

namespace FindTeacher.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int? category, string name, int page = 1)
        {
            int pageSize = 5;
            IQueryable<Post> posts = _context.Posts.Include(p => p.PostCategory).OrderByDescending(b => b.Created_date);

            //фильтрация
            if (category != null && category != 0)
            {
                posts = posts.Where(p => p.PostCategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                posts = posts.Where(p => p.Title.Contains(name));
            }

            var count = await posts.CountAsync();
            var items = await posts.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            PostViewModel viewModel = new PostViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items,
                FilterPostViewModel = new FilterPostViewModel(_context.PostCategories.ToList(), category, name),
            };

            //var applicationDbContext = _context.Posts.Include(p => p.PostCategory).OrderByDescending(b => b.Created_date);
            //return View(await applicationDbContext.ToListAsync());
            return View(viewModel);
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.PostCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            post.Views = post.Views + 1;
            _context.Update(post);
            await _context.SaveChangesAsync();

            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["PostCategoryId"] = new SelectList(_context.PostCategories, "Id", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Pre_content,Content,Author,Created_date,ImageUrl,Views,Enabled,Comments_enabled,PostCategoryId")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostCategoryId"] = new SelectList(_context.PostCategories, "Id", "Id", post.PostCategoryId);
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["PostCategoryId"] = new SelectList(_context.PostCategories, "Id", "Id", post.PostCategoryId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,Pre_content,ImageUrl,Views,Enabled,Comments_enabled,PostCategoryId")] Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["PostCategoryId"] = new SelectList(_context.PostCategories, "Id", "Id", post.PostCategoryId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.PostCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
