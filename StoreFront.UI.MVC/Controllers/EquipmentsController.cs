using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;
using StoreFront.UI.MVC.Utilities;

namespace StoreFront.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EquipmentsController : Controller
    {
        private readonly StoreFrontContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        //    public EquipmentsController(StoreFrontContext context, IWebHostEnvironment webHostEnvironment)
        //    {
        //        _context = context;
        //        _webHostEnvironment = webHostEnvironment;
        //    }
        public EquipmentsController(StoreFrontContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Equipments
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var storeFrontContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Status).Include(e => e.Store);
            return View(await storeFrontContext.ToListAsync());
        }

        [AllowAnonymous]
        public async Task<IActionResult> TiledView()
        {
            var storeFrontContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Status).Include(e => e.Store);
            return View(await storeFrontContext.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.EquipmentType)
                .Include(e => e.Status)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create

        public IActionResult Create()
        {
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName");
            ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName");
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("EquipmentId,EquipmentName,EquipmentPrice,EquipmentDescription,StoreId,EquipmentTypeId,StatusId,ProductImage, UnitsInStock")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                if (equipment.Image != null)
                {
                    string ext = Path.GetExtension(equipment.Image.FileName);

                    string[] validExts = { ".jpeg", ".jpg", ".gif", ".png" };

                    if (validExts.Contains(ext.ToLower()) && equipment.Image.Length < 4_194_303)
                    {
                        equipment.ProductImage = Guid.NewGuid() + ext;

                        string iAmRoot = _webHostEnvironment.WebRootPath;

                        string fullImage = iAmRoot + "/images";

                        using (var memoryStream = new MemoryStream())
                        {
                            await equipment.Image.CopyToAsync(memoryStream);

                            using (var img = Image.FromStream(memoryStream))
                            {
                                int maxImageSize = 500; //size in pixels
                                int maxThumbSize = 100; //size in pixels

                                ImageUtility.ResizeImage(iAmRoot, equipment.ProductImage, img, maxImageSize, maxThumbSize);

                                //myFile.Save("path/to/folder", "filename") > How to save something 
                                //that is NOT an image.

                            }
                        }
                    }
                }

                else
                {
                    equipment.ProductImage = "noimage.png";
                }


                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
            ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
            ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,EquipmentName,EquipmentPrice,EquipmentDescription,StoreId,EquipmentTypeId,StatusId,ProductImage, UnitsInStock")] Equipment equipment)
        {
            if (id != equipment.EquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.EquipmentId))
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
            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
            ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.EquipmentType)
                .Include(e => e.Status)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipment == null)
            {
                return Problem("Entity set 'StoreFrontContext.Equipment'  is null.");
            }
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
          return _context.Equipment.Any(e => e.EquipmentId == id);
        }
    }
}







//{
//    [Authorize(Roles = "Admin")]
//    public class EquipmentsController : Controller
//{
//    private readonly StoreFrontContext _context;

//    private readonly IWebHostEnvironment _webHostEnvironment;

//    public EquipmentsController(StoreFrontContext context, IWebHostEnvironment webHostEnvironment)
//    {
//        _context = context;
//        _webHostEnvironment = webHostEnvironment;
//    }

//    // GET: Equipments
//    [AllowAnonymous]
//    public async Task<IActionResult> Index()
//    {
//        var storeFrontContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Status).Include(e => e.Store);
//        return View(await storeFrontContext.ToListAsync());
//    }

//    [AllowAnonymous]
//    public async Task<IActionResult> TiledView()
//    {
//        var storeFrontContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Status).Include(e => e.Store);
//        return View(await storeFrontContext.ToListAsync());
//    }


//    // GET: Equipments/Details/5
//    public async Task<IActionResult> Details(int? id)
//    {
//        if (id == null || _context.Equipment == null)
//        {
//            return NotFound();
//        }

//        var equipment = await _context.Equipment
//            .Include(e => e.EquipmentType)
//            .Include(e => e.Status)
//            .Include(e => e.Store)
//            .FirstOrDefaultAsync(m => m.EquipmentId == id);
//        if (equipment == null)
//        {
//            return NotFound();
//        }

//        return View(equipment);
//    }

//    // GET: Equipments/Create
//    public IActionResult Create()
//    {
//        ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName");
//        ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName");
//        ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber");
//        return View();
//    }

//    // POST: Equipments/Create
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Create([Bind("EquipmentId,EquipmentName,EquipmentPrice,EquipmentDescription,StoreId,EquipmentTypeId,StatusId,ProductImage")] Equipment equipment)
//    {
//        if (ModelState.IsValid)
//        {
//            if (equipment.Image != null)
//            {
//                string ext = Path.GetExtension(equipment.Image.FileName);

//                string[] validExts = { ".jpeg", ".jpg", ".gif", ".png" };

//                if (validExts.Contains(ext.ToLower()) && equipment.Image.Length < 4_194_303)
//                {
//                    equipment.ProductImage = Guid.NewGuid() + ext;

//                    string iAmRoot = _webHostEnvironment.WebRootPath;

//                    string fullImage = iAmRoot + "/images";

//                    using (var memoryStream = new MemoryStream())
//                    {
//                        await equipment.Image.CopyToAsync(memoryStream);

//                        using (var img = Image.FromStream(memoryStream))
//                        {
//                            int maxImageSize = 500; //size in pixels
//                            int maxThumbSize = 100; //size in pixels

//                            ImageUtility.ResizeImage(iAmRoot, equipment.ProductImage, img, maxImageSize, maxThumbSize);

//                            //myFile.Save("path/to/folder", "filename") > How to save something 
//                            //that is NOT an image.

//                        }
//                    }
//                }
//            }

//            else
//            {
//                equipment.ProductImage = "noimage.png";
//            }


//            _context.Add(equipment);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
//        ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
//        ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
//        return View(equipment);
//    }

//    // GET: Equipments/Edit/5
//    public async Task<IActionResult> Edit(int? id)
//    {
//        if (id == null || _context.Equipment == null)
//        {
//            return NotFound();
//        }

//        var equipment = await _context.Equipment.FindAsync(id);
//        if (equipment == null)
//        {
//            return NotFound();
//        }
//        ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
//        ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
//        ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
//        return View(equipment);
//    }

//    // POST: Equipments/Edit/5
//    // To protect from overposting attacks, enable the specific properties you want to bind to.
//    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,EquipmentName,EquipmentPrice,EquipmentDescription,StoreId,EquipmentTypeId,StatusId,ProductImage")] Equipment equipment)
//    {
//        if (id != equipment.EquipmentId)
//        {
//            return NotFound();
//        }

//        if (ModelState.IsValid)
//        {
//            try
//            {
//                _context.Update(equipment);
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!EquipmentExists(equipment.EquipmentId))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//            return RedirectToAction(nameof(Index));
//        }
//        ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName", equipment.EquipmentTypeId);
//        ViewData["StatusId"] = new SelectList(_context.EquipmentStatuses, "StatusId", "StatusName", equipment.StatusId);
//        ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "PhoneNumber", equipment.StoreId);
//        return View(equipment);
//    }

//    // GET: Equipments/Delete/5
//    public async Task<IActionResult> Delete(int? id)
//    {
//        if (id == null || _context.Equipment == null)
//        {
//            return NotFound();
//        }

//        var equipment = await _context.Equipment
//            .Include(e => e.EquipmentType)
//            .Include(e => e.Status)
//            .Include(e => e.Store)
//            .FirstOrDefaultAsync(m => m.EquipmentId == id);
//        if (equipment == null)
//        {
//            return NotFound();
//        }

//        return View(equipment);
//    }

//    // POST: Equipments/Delete/5
//    [HttpPost, ActionName("Delete")]
//    [ValidateAntiForgeryToken]
//    public async Task<IActionResult> DeleteConfirmed(int id)
//    {
//        if (_context.Equipment == null)
//        {
//            return Problem("Entity set 'StoreFrontContext.Equipment'  is null.");
//        }
//        var equipment = await _context.Equipment.FindAsync(id);
//        if (equipment != null)
//        {
//            _context.Equipment.Remove(equipment);
//        }

//        await _context.SaveChangesAsync();
//        return RedirectToAction(nameof(Index));
//    }

//    private bool EquipmentExists(int id)
//    {
//        return _context.Equipment.Any(e => e.EquipmentId == id);
//    }
//}
//}