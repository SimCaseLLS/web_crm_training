namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArticleDocuments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDocuments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Data = c.Binary(),
                        ContentType = c.String(),
                        ArticleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FileDocuments", "ArticleId", "dbo.Articles");
            DropIndex("dbo.FileDocuments", new[] { "ArticleId" });
            DropTable("dbo.FileDocuments");
        }
    }
}
