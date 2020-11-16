using System.Data.Entity;

namespace Crowd_knowledge_contribution.Models
{
    public class PlatformDbContext : DbContext
    {
        public PlatformDbContext() : 
            base("DBConnectionString")
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}