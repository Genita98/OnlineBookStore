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
            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


            }
            return View(obj);
        }





        //Edit part


        public IActionResult Edit()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _db.Categories.Find(id);

            if(categoryFromDb == null)
            {
                return NotFound();  
            }

            return View(categoryFromDb);


            
            return View(obj);
        }
    }
}
