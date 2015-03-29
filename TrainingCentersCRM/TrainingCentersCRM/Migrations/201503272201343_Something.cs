namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Something : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainingCourses", "ShortDescription", c => c.String(maxLength: 2048));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingCourses", "ShortDescription", c => c.String(maxLength: 1023));
        }
    }
}
