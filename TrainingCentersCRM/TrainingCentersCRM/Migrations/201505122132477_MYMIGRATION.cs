namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MYMIGRATION : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Annotation", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Articles", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.TrainingCourses", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.TrainingCourses", "ShortDescription", c => c.String(nullable: false, maxLength: 2048));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingCourses", "ShortDescription", c => c.String(maxLength: 2048));
            AlterColumn("dbo.TrainingCourses", "Title", c => c.String(maxLength: 255));
            AlterColumn("dbo.Articles", "Text", c => c.String());
            AlterColumn("dbo.Articles", "Annotation", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
