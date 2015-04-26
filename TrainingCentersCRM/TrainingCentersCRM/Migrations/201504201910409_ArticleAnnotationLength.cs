namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleAnnotationLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Annotation", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "Annotation", c => c.String());
        }
    }
}
