using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SapereAude.Data;
using SapereAude.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapereAude.Controllers
{
    public class SuggestionController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SuggestionController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //getall
            var objSuggestionlist = _db.Suggestions.ToList();

            //populate dropdown
            //var dropdownVD = new SelectList(_db.Categories.ToList(), "Id", "CategoryName");
            //ViewData["StudDataVD"] = dropdownVD;
            //using viewbag  
            ViewBag.dropdownVD = new SelectList(_db.Categories.ToList(), "Id", "CategoryName");

            return View(objSuggestionlist);
        }

        //CREATE

        //GET
        public IActionResult Create()
        {
            ViewBag.dropdownVD = new SelectList(_db.Categories.ToList(), "Id", "CategoryName");

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Suggestion obj)
        {
            //if (obj.Title == null)
            //{
            //    ModelState.AddModelError("CustomError", "Naslov/tema moraju biti ");
            //}

            if (ModelState.IsValid)
            {
                _db.Suggestions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Prijedlog uspješno kreiran.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //EDIT

        //GET
        public IActionResult Edit(int? id)
        {
            if (id==null || id == 0)
            {
                return NotFound();
            }

            var suggestionFromDb = _db.Suggestions.Find(id);

            if(suggestionFromDb == null)
            {
                return NotFound();
            }

            ViewBag.dropdownVD = new SelectList(_db.Categories.ToList(), "Id", "CategoryName");

            return View(suggestionFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Suggestion obj)
        {
            //if (obj.Title == null)
            //{
            //    ModelState.AddModelError("CustomError", "Naslov/tema moraju biti ");
            //}

            if (ModelState.IsValid)
            {
                _db.Suggestions.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Prijedlog uspješno uređen.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //DELETE
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var suggestionFromDb = _db.Suggestions.Find(id);

            if (suggestionFromDb == null)
            {
                return NotFound();
            }

            ViewBag.dropdownVD = new SelectList(_db.Categories.ToList(), "Id", "CategoryName");

            return View(suggestionFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Suggestion obj)
        {
            //if (obj.Title == null)
            //{
            //    ModelState.AddModelError("CustomError", "Naslov/tema moraju biti ");
            //}

            if (ModelState.IsValid)
            {
                _db.Suggestions.Remove(obj);
                _db.SaveChanges();
                TempData["success"] = "Prijedlog uspješno izbrisan.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
