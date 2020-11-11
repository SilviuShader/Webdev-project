namespace Crowd_knowledge_contribution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        VersionId = c.Int(nullable: false),
                        Name = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        LastModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.VersionId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
