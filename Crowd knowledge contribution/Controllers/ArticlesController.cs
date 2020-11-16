using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly PlatformDbContext _database = new PlatformDbContext();

        // GET: Articles
        [HttpGet]
        public ActionResult Index()
        {
            //pagina cu toate
            ViewBag.Articles = _database.Articles.Include("Domain");
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var article = new Article {Dom = GetAllDomains()};

            return View(article);
        }

        /*
        [HttpPost]
        public ActionResult New()
        {

        }*/

        private IEnumerable<SelectListItem> GetAllDomains()
        {
            var selectList = new List<SelectListItem>();

            var domains = from domain in _database.Domains
                select domain;

            foreach (var domain in domains)
            {
                selectList.Add(new SelectListItem
                {
                    Value = domain.DomainId.ToString(),
                    Text = domain.DomainName
                });
            }
            
            return selectList;
        }
    }
}