using System.Web.Mvc;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Controllers
{
    public class ArticlesController : Controller
    {
        readonly PlatformDbContext m_database = new PlatformDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            ViewBag.Articles = m_database.Articles;
            return View();
        }
    }
}