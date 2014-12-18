namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        IdTrainingCenter = c.String(),
                        Parent_Id = c.Int(nullable: false),
                        Ord_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QualificationCertification", "Qualifications_Id", c => c.Int());
            AddColumn("dbo.Qualifications", "ParentId", c => c.Int());
            CreateIndex("dbo.QualificationCertification", "Qualifications_Id");
            AddForeignKey("dbo.QualificationCertification", "Qualifications_Id", "dbo.Qualifications", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QualificationCertification", "Qualifications_Id", "dbo.Qualifications");
            DropIndex("dbo.QualificationCertification", new[] { "Qualifications_Id" });
            DropColumn("dbo.Qualifications", "ParentId");
            DropColumn("dbo.QualificationCertification", "Qualifications_Id");
            DropTable("dbo.Menus");
        }
    }
}
