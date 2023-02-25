using HadflixWeb.Data;
using HadflixWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HadflixWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;
            return View(categoryList);
        }
        
        //GET
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Category category)
        {
            if (category.CategoryName == category.DisplayOrder.ToString())
                ModelState.AddModelError("CategoryName", "Category name and Display Order cannot be the exact same");

            if(!ModelState.IsValid)
                return View(category);

            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        //GET
        public IActionResult Update(long? id)
        {
            if (id == null || id <= 0)
                return NotFound();

            var existingCategory = _db.Categories.Find(id);
            if (existingCategory == null)
                return NotFound();

            return View(existingCategory);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category category)
        {
            if (category.CategoryName == category.DisplayOrder.ToString())
                ModelState.AddModelError("CategoryName", "Category name and Display Order cannot be the exact same");

            if(!ModelState.IsValid)
                return View(category);

            _db.Categories.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Delete(long? id)
        {
            if (id == null || id <= 0)
                return NotFound();

            var existingCategory = _db.Categories.Find(id);
            if (existingCategory == null)
                return NotFound();

            return View(existingCategory);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {

            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
