using Crowd_knowledge_contribution.Models;

namespace Crowd_knowledge_contribution.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Crowd_knowledge_contribution.Models.PlatformDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = typeof(PlatformDbContext).FullName;
        }

        protected override void Seed(Crowd_knowledge_contribution.Models.PlatformDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
