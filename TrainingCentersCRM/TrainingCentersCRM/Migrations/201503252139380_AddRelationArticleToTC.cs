namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationArticleToTC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "TrainingCenterId", c => c.Int());
            CreateIndex("dbo.Articles", "TrainingCenterId");
            AddForeignKey("dbo.Articles", "TrainingCenterId", "dbo.TrainingCenters", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "TrainingCenterId", "dbo.TrainingCenters");
            DropIndex("dbo.Articles", new[] { "TrainingCenterId" });
            DropColumn("dbo.Articles", "TrainingCenterId");
        }
    }
}
