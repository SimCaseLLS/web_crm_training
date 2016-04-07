namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacancyTrainingCenter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vacancies", "IdTrainingCenter", c => c.Int());
            CreateIndex("dbo.Vacancies", "IdTrainingCenter");
            AddForeignKey("dbo.Vacancies", "IdTrainingCenter", "dbo.TrainingCenters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacancies", "IdTrainingCenter", "dbo.TrainingCenters");
            DropIndex("dbo.Vacancies", new[] { "IdTrainingCenter" });
            DropColumn("dbo.Vacancies", "IdTrainingCenter");
        }
    }
}
