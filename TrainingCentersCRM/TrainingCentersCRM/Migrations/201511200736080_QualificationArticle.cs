namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QualificationArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qualifications", "ArticleId", c => c.Int());
            CreateIndex("dbo.Qualifications", "ArticleId");
            AddForeignKey("dbo.Qualifications", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Qualifications", new[] { "ArticleId" });
            DropColumn("dbo.Qualifications", "ArticleId");
        }
    }
}
