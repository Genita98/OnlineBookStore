using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        public readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


            }
            return View(obj);
        }





        //Edit part

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(obj);

        }


        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);

        }

        //POST
        [HttpPost,ActionName ("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int? id)
        {
            var obj = _db.Categories.Find(id);

            if(obj == null)
            {
                return NotFound();
            }
           
                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");


        }

    }
}
