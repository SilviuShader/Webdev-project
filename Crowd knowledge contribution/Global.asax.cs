using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PlatformDbContext, 
                Migrations.Configuration>("DBConnectionString"));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
