using System.Linq;
using System.Web.Mvc;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly PlatformDbContext _database = new PlatformDbContext();
        // GET: Categories
        public ActionResult Index()
        {
            ViewBag.Categories = _database.Categories;
            ViewBag.Message = TempData["message"];
            return View();
        }

        public ActionResult Show(int id)
        {
            var category = _database.Categories.Find(id);

            if (category is null)
            {
                TempData["message"] = "Nu există articolul cerut"; 
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}