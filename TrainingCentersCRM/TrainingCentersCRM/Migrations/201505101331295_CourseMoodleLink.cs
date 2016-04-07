namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseMoodleLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCourses", "MoodleId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingCourses", "MoodleId");
        }
    }
}
