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
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
        }

        //GET Create Action
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SpecialTags specialTag)
        {
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Add(specialTag);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(specialTag);
        }

        //GET Edit Action
        public IActionResult Edit(int? Id)
        {
            if (Id != null)
            {
                return View(_db.SpecialTags.Find(Id));
            }
            return NotFound();
        }

        //POST Edit Action
        [HttpPost,ActionName("Edit")]
        public IActionResult Edit(int? id, SpecialTags specialTag)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.SpecialTags.Update(specialTag);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialTag);
        }

        //GET Details Action
        public IActionResult Details(int? id)
        {
            return View(_db.SpecialTags.Find(id));
        }

        //GET Delete Action
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_db.SpecialTags.Find(id));
        }

        //POST Delete
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTag(int? id)
        {
            if (id != null)
            {
                _db.SpecialTags.Remove(_db.SpecialTags.Find(id));
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
