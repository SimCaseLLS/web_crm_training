namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleImageContentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ContentType");
        }
    }
}
