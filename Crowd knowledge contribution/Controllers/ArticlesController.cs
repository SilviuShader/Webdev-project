using System.Web.Mvc;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly PlatformDbContext _database = new PlatformDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            //pagina cu toate
            ViewBag.Articles = _database.Articles.Include("Domain");
            return View();
        }
    }
}