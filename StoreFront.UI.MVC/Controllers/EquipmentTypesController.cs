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
    public class EquipmentTypesController : Controller
    {
        private readonly StoreFrontContext _context;

        public EquipmentTypesController(StoreFrontContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: EquipmentTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.EquipmentTypes.ToListAsync());
        }

        [AllowAnonymous]
        // GET: EquipmentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipmentTypes == null)
            {
                return NotFound();
            }

            var equipmentType = await _context.EquipmentTypes
                .FirstOrDefaultAsync(m => m.EquipmentTypeId == id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            return View(equipmentType);
        }

        // GET: EquipmentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentTypeId,TypeName")] EquipmentType equipmentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentTypes == null)
            {
                return NotFound();
            }

            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType == null)
            {
                return NotFound();
            }
            return View(equipmentType);
        }

        // POST: EquipmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentTypeId,TypeName")] EquipmentType equipmentType)
        {
            if (id != equipmentType.EquipmentTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentTypeExists(equipmentType.EquipmentTypeId))
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
            return View(equipmentType);
        }

        // GET: EquipmentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentTypes == null)
            {
                return NotFound();
            }

            var equipmentType = await _context.EquipmentTypes
                .FirstOrDefaultAsync(m => m.EquipmentTypeId == id);
            if (equipmentType == null)
            {
                return NotFound();
            }

            return View(equipmentType);
        }

        // POST: EquipmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentTypes == null)
            {
                return Problem("Entity set 'StoreFrontContext.EquipmentTypes'  is null.");
            }
            var equipmentType = await _context.EquipmentTypes.FindAsync(id);
            if (equipmentType != null)
            {
                _context.EquipmentTypes.Remove(equipmentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentTypeExists(int id)
        {
          return _context.EquipmentTypes.Any(e => e.EquipmentTypeId == id);
        }
    }
}
