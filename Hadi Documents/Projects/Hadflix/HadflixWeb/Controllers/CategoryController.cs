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
    }
}
