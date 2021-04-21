using GraniteHouse.Data;
using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductTypes productType)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productType);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }


        //GET EDIT Action
        public IActionResult Edit(int? Id)
        {
            var toEdit =  _db.ProductTypes.Find(Id);
            if (toEdit != null)
            {
                return View(toEdit);
            }
            return NotFound();
        }

        //POST Edit Action
        [HttpPost]
        public IActionResult Edit(int id, ProductTypes productType)
        {
            if (id != productType.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Update(productType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productType);
        }

        //GET Details Action Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = await _db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Delete action Method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTypes = await _db.ProductTypes.FindAsync(id);
            _db.ProductTypes.Remove(productTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
