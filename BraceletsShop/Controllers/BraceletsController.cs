using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BraceletsShop.Data;
using BraceletsShop.Models;

namespace BraceletsShop.Controllers
{
    public class BraceletsController : Controller
    {
        private readonly BraceletsShopContext _context;

        public BraceletsController(BraceletsShopContext context)
        {
            _context = context;
        }

        // GET: Bracelets
       
        public async Task<IActionResult> Index(string braceletCat, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Bracelet
                                            orderby m.Category
                                            select m.Category;

            var bracelet = from m in _context.Bracelet
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                bracelet = bracelet.Where(s => s.Category.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(braceletCat))
            {
                bracelet = bracelet.Where(x => x.Category == braceletCat);
            }

            var braceletCatVM = new BraceletCatViewModel
            {
                Category = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Bracelets = await bracelet.ToListAsync()
            };

            return View(braceletCatVM);
        }

        // GET: Bracelets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracelet = await _context.Bracelet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bracelet == null)
            {
                return NotFound();
            }

            return View(bracelet);
        }

        // GET: Bracelets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bracelets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Category,Material,CollectionDate,Price,Rating")] Bracelet bracelet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bracelet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bracelet);
        }

        // GET: Bracelets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracelet = await _context.Bracelet.FindAsync(id);
            if (bracelet == null)
            {
                return NotFound();
            }
            return View(bracelet);
        }

        // POST: Bracelets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Material,CollectionDate,Price,Rating")] Bracelet bracelet)
        {
            if (id != bracelet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bracelet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BraceletExists(bracelet.ID))
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
            return View(bracelet);
        }

        // GET: Bracelets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bracelet = await _context.Bracelet
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bracelet == null)
            {
                return NotFound();
            }

            return View(bracelet);
        }

        // POST: Bracelets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bracelet = await _context.Bracelet.FindAsync(id);
            _context.Bracelet.Remove(bracelet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BraceletExists(int id)
        {
            return _context.Bracelet.Any(e => e.ID == id);
        }
    }
}
