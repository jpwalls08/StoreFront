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
using X.PagedList; //Paged List - Step 2

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

        #region Filter/Paging Steps
        //---- SEARCH ----//
        //1) Create form in the view (for the SEARCH portion, only need 1 textbox and a submit button - <select> will be added later)
        //2) Update controller Action ([A] add param, [B]add search filter logic)

        //---- DDL ----//
        //1) Create ViewData[] object in Controller action (this sends DDL list to the View)
        //2) Add <select> inside of <form>
        //3) Update Controller Action ([A] add param, [B] add category filter logic)

        //---- PAGED LIST ----//
        //1) Install package for X.PagedList.Mvc.Core
        //      - Open Package Manger Console -> select the UI project -> install-package x.pagedlist.mvc.core
        //2) Add using statements and update model declaration in the View
        //3) Add param to Controller Action
        //4) Add page size variable in Action
        //5) Update return statement in Controller Action
        //6) Add Counter in View

        // 7) Create a new CSS file in wwwroot/css named 'PagedList.css'
        //      - NOTE: may need to go to the package's NuGet page and copy the CSS directly OR copy from an existing project :)
        //      - X.PagedList CSS file link (go here to copy the code): https://github.com/dncuug/X.PagedList/blob/master/examples/X.PagedList.Mvc.Example.Core/wwwroot/css/PagedList.css
        // 0) Add a <link> to the _Layout referencing 'PagedList.css'
        #endregion


        [AllowAnonymous]
        //public async Task<IActionResult> TiledView()
        //{
        //    var storeFrontContext = _context.Equipment.Include(e => e.EquipmentType).Include(e => e.Status).Include(e => e.Store);
        //    return View(await storeFrontContext.ToListAsync());
        //}

        public async Task<IActionResult> TiledView(string searchTerm, int categoryId = 0 , int page = 1)
        {
            int pageSize = 6;

            var equipment = _context.Equipment.Where(e => e.StatusId != 4)
                .Include(e => e.EquipmentType).Include(e => e.Store).Include(e => e.OrderEquipments).ToList();

            ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName");

            if (categoryId != 0)
            {
                equipment = equipment.Where(e => e.EquipmentTypeId == categoryId).ToList();

                ViewData["EquipmentTypeId"] = new SelectList(_context.EquipmentTypes, "EquipmentTypeId", "TypeName");
            }

            if (!String.IsNullOrEmpty(searchTerm))
            {
                equipment = equipment.Where(e =>
                                                e.EquipmentName.ToLower().Contains(searchTerm.ToLower())
                                                || e.Store.StoreName.ToLower().Contains(searchTerm.ToLower())
                                                || (e.EquipmentDescription != null && e.EquipmentDescription.ToLower().Contains(searchTerm.ToLower()))
                                                || e.EquipmentType.TypeName.ToLower().Contains(searchTerm.ToLower())).ToList();

                ViewBag.SearchTerm = searchTerm;
                ViewBag.NbrResults = equipment.Count;
            }
            else
            {
                ViewBag.SearchTerm = null;
                ViewBag.NbrResults = null;
            }

            return View(equipment.ToPagedList(page, pageSize));
        }


        // GET: Equipments/Details/5
        [AllowAnonymous]
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
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "StoreName");
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
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "StoreName", equipment.StoreId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        [Authorize]
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
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "StoreName", equipment.StoreId);
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
            ViewData["StoreId"] = new SelectList(_context.GolfStores, "StoreId", "StoreName", equipment.StoreId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
          return (_context.Equipment?.Any(e => e.EquipmentId == id)).GetValueOrDefault();
        }
    }
}
