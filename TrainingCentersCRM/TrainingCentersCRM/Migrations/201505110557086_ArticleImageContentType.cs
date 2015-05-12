namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleImageContentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Image", c => c.Binary()); 
            AddColumn("dbo.Articles", "ContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Image");
            DropColumn("dbo.Articles", "ContentType");
        }
    }
}
