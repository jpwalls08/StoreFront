using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class EquipmentStatusController : Controller
    {
        private readonly StoreFrontContext _context;

        public EquipmentStatusController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: EquipmentStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.EquipmentStatuses.ToListAsync());
        }

        // GET: EquipmentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipmentStatuses == null)
            {
                return NotFound();
            }

            var equipmentStatus = await _context.EquipmentStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (equipmentStatus == null)
            {
                return NotFound();
            }

            return View(equipmentStatus);
        }

        // GET: EquipmentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusId,StatusName")] EquipmentStatus equipmentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentStatus);
        }

        // GET: EquipmentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentStatuses == null)
            {
                return NotFound();
            }

            var equipmentStatus = await _context.EquipmentStatuses.FindAsync(id);
            if (equipmentStatus == null)
            {
                return NotFound();
            }
            return View(equipmentStatus);
        }

        // POST: EquipmentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusId,StatusName")] EquipmentStatus equipmentStatus)
        {
            if (id != equipmentStatus.StatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentStatusExists(equipmentStatus.StatusId))
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
            return View(equipmentStatus);
        }

        // GET: EquipmentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentStatuses == null)
            {
                return NotFound();
            }

            var equipmentStatus = await _context.EquipmentStatuses
                .FirstOrDefaultAsync(m => m.StatusId == id);
            if (equipmentStatus == null)
            {
                return NotFound();
            }

            return View(equipmentStatus);
        }

        // POST: EquipmentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentStatuses == null)
            {
                return Problem("Entity set 'StoreFrontContext.EquipmentStatuses'  is null.");
            }
            var equipmentStatus = await _context.EquipmentStatuses.FindAsync(id);
            if (equipmentStatus != null)
            {
                _context.EquipmentStatuses.Remove(equipmentStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentStatusExists(int id)
        {
          return _context.EquipmentStatuses.Any(e => e.StatusId == id);
        }
    }
}
