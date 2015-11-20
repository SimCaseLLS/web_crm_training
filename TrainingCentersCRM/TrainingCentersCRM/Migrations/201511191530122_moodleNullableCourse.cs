namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moodleNullableCourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainingCourses", "MoodleId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingCourses", "MoodleId", c => c.Int(nullable: false));
        }
    }
}
