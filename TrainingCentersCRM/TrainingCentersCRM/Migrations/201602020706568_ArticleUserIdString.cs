namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleUserIdString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "UserId", c => c.Int(nullable: false));
        }
    }
}
