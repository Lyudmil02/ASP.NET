using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieWorld.Data;

namespace MovieWorld.Controllers
{
    public class CatalogsController : Controller
    {
        private readonly MovieWorldContext _context;

        public CatalogsController(MovieWorldContext context)
        {
            _context = context;
        }

        // GET: Catalogs
        public async Task<IActionResult> Index()
        {
            var movieWorldContext = _context.Catalogs.Include(c => c.User);
            return View(await movieWorldContext.ToListAsync());
        }

        // GET: Catalogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var catalog = await _context.Catalogs
            //    .Include(c => c.User)
            //    .FirstOrDefaultAsync(m => m.CatalogId == id);

            var catalog = await _context.Catalogs
                .Include(c => c.Movies)
                .ThenInclude(m=>m.Movie)
                .FirstOrDefaultAsync(m => m.CatalogId == id);
                

            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // GET: Catalogs/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName");
            return View();
        }

        // POST: Catalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CatalogId,CatalogName,Description,UserId")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", catalog.UserId);
            return View(catalog);
        }

        // GET: Catalogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", catalog.UserId);
            return View(catalog);
        }

        // POST: Catalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CatalogId,CatalogName,Description,UserId")] Catalog catalog)
        {
            if (id != catalog.CatalogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.CatalogId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "FullName", catalog.UserId);
            return View(catalog);
        }

        // GET: Catalogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catalog = await _context.Catalogs
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CatalogId == id);
            if (catalog == null)
            {
                return NotFound();
            }

            return View(catalog);
        }

        // POST: Catalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalogs.Any(e => e.CatalogId == id);
        }
    }
}
