namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedbackTC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "TrainingCenter_Id1", "dbo.TrainingCenters");
            DropIndex("dbo.Feedbacks", new[] { "TrainingCenter_Id1" });
            RenameColumn(table: "dbo.Feedbacks", name: "TrainingCenter_Id1", newName: "IdTrainingCenter");
            AlterColumn("dbo.Feedbacks", "IdTrainingCenter", c => c.Int(nullable: false));
            CreateIndex("dbo.Feedbacks", "IdTrainingCenter");
            AddForeignKey("dbo.Feedbacks", "IdTrainingCenter", "dbo.TrainingCenters", "Id", cascadeDelete: true);
            DropColumn("dbo.Feedbacks", "TrainingCenter_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "TrainingCenter_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Feedbacks", "IdTrainingCenter", "dbo.TrainingCenters");
            DropIndex("dbo.Feedbacks", new[] { "IdTrainingCenter" });
            AlterColumn("dbo.Feedbacks", "IdTrainingCenter", c => c.Int());
            RenameColumn(table: "dbo.Feedbacks", name: "IdTrainingCenter", newName: "TrainingCenter_Id1");
            CreateIndex("dbo.Feedbacks", "TrainingCenter_Id1");
            AddForeignKey("dbo.Feedbacks", "TrainingCenter_Id1", "dbo.TrainingCenters", "Id");
        }
    }
}
