using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GolfStoresController : Controller
    {
        private readonly StoreFrontContext _context;

        public GolfStoresController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: GolfStores
        public async Task<IActionResult> Index()
        {
              return View(await _context.GolfStores.ToListAsync());
        }

        // GET: GolfStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GolfStores == null)
            {
                return NotFound();
            }

            var golfStore = await _context.GolfStores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (golfStore == null)
            {
                return NotFound();
            }

            return View(golfStore);
        }

        // GET: GolfStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GolfStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreId,StoreName,PhoneNumber,Region,Country,ZipCode,State,Address")] GolfStore golfStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(golfStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(golfStore);
        }

        // GET: GolfStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GolfStores == null)
            {
                return NotFound();
            }

            var golfStore = await _context.GolfStores.FindAsync(id);
            if (golfStore == null)
            {
                return NotFound();
            }
            return View(golfStore);
        }

        // POST: GolfStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreId,StoreName,PhoneNumber,Region,Country,ZipCode,State,Address")] GolfStore golfStore)
        {
            if (id != golfStore.StoreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(golfStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GolfStoreExists(golfStore.StoreId))
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
            return View(golfStore);
        }

        // GET: GolfStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GolfStores == null)
            {
                return NotFound();
            }

            var golfStore = await _context.GolfStores
                .FirstOrDefaultAsync(m => m.StoreId == id);
            if (golfStore == null)
            {
                return NotFound();
            }

            return View(golfStore);
        }

        // POST: GolfStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GolfStores == null)
            {
                return Problem("Entity set 'StoreFrontContext.GolfStores'  is null.");
            }
            var golfStore = await _context.GolfStores.FindAsync(id);
            if (golfStore != null)
            {
                _context.GolfStores.Remove(golfStore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GolfStoreExists(int id)
        {
          return _context.GolfStores.Any(e => e.StoreId == id);
        }
    }
}
