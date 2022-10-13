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
    public class OrderEquipmentsController : Controller
    {
        private readonly StoreFrontContext _context;

        public OrderEquipmentsController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: OrderEquipments
        public async Task<IActionResult> Index()
        {
            var storeFrontContext = _context.OrderEquipments.Include(o => o.Equipment).Include(o => o.Order);
            return View(await storeFrontContext.ToListAsync());
        }

        // GET: OrderEquipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrderEquipments == null)
            {
                return NotFound();
            }

            var orderEquipment = await _context.OrderEquipments
                .Include(o => o.Equipment)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderEquipmentId == id);
            if (orderEquipment == null)
            {
                return NotFound();
            }

            return View(orderEquipment);
        }

        // GET: OrderEquipments/Create
        public IActionResult Create()
        {
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "EquipmentId", "EquipmentName");
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "ShipCity");
            return View();
        }

        // POST: OrderEquipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderEquipmentId,EquipmentId,OrderId,Quantity,EquipmentPrice")] OrderEquipment orderEquipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "EquipmentId", "EquipmentName", orderEquipment.EquipmentId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "ShipCity", orderEquipment.OrderId);
            return View(orderEquipment);
        }

        // GET: OrderEquipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrderEquipments == null)
            {
                return NotFound();
            }

            var orderEquipment = await _context.OrderEquipments.FindAsync(id);
            if (orderEquipment == null)
            {
                return NotFound();
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "EquipmentId", "EquipmentName", orderEquipment.EquipmentId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "ShipCity", orderEquipment.OrderId);
            return View(orderEquipment);
        }

        // POST: OrderEquipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderEquipmentId,EquipmentId,OrderId,Quantity,EquipmentPrice")] OrderEquipment orderEquipment)
        {
            if (id != orderEquipment.OrderEquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEquipmentExists(orderEquipment.OrderEquipmentId))
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
            ViewData["EquipmentId"] = new SelectList(_context.Equipment, "EquipmentId", "EquipmentName", orderEquipment.EquipmentId);
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "ShipCity", orderEquipment.OrderId);
            return View(orderEquipment);
        }

        // GET: OrderEquipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderEquipments == null)
            {
                return NotFound();
            }

            var orderEquipment = await _context.OrderEquipments
                .Include(o => o.Equipment)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.OrderEquipmentId == id);
            if (orderEquipment == null)
            {
                return NotFound();
            }

            return View(orderEquipment);
        }

        // POST: OrderEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrderEquipments == null)
            {
                return Problem("Entity set 'StoreFrontContext.OrderEquipments'  is null.");
            }
            var orderEquipment = await _context.OrderEquipments.FindAsync(id);
            if (orderEquipment != null)
            {
                _context.OrderEquipments.Remove(orderEquipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderEquipmentExists(int id)
        {
          return _context.OrderEquipments.Any(e => e.OrderEquipmentId == id);
        }
    }
}
