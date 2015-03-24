namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacancyAndQualificationRelationCorrected : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QualificationVacancy", "IdVacancy", "dbo.Vacancies");
            DropForeignKey("dbo.QualificationVacancy", "IdQualification", "dbo.Qualifications");
            DropIndex("dbo.QualificationVacancy", new[] { "IdVacancy" });
            DropIndex("dbo.QualificationVacancy", new[] { "IdQualification" });
            CreateTable(
                "dbo.QualificationVacancies",
                c => new
                    {
                        Qualification_Id = c.Int(nullable: false),
                        Vacancy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Qualification_Id, t.Vacancy_Id })
                .ForeignKey("dbo.Qualifications", t => t.Qualification_Id, cascadeDelete: true)
                .ForeignKey("dbo.Vacancies", t => t.Vacancy_Id, cascadeDelete: true)
                .Index(t => t.Qualification_Id)
                .Index(t => t.Vacancy_Id);
            
            //AddColumn("dbo.QualificationVacancies", "Qualification_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.QualificationVacancies", "Vacancy_Id", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.QualificationVacancy");
            //AddPrimaryKey("dbo.QualificationVacancies", new[] { "Qualification_Id", "Vacancy_Id" });
            //DropColumn("dbo.QualificationVacancies", "Id");
            //DropColumn("dbo.QualificationVacancies", "IdQualification");
            //DropColumn("dbo.QualificationVacancies", "IdVacancy");
            DropTable("dbo.QualificationVacancy");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QualificationVacancy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQualification = c.Int(),
                        IdVacancy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QualificationVacancies", "IdVacancy", c => c.Int());
            AddColumn("dbo.QualificationVacancies", "IdQualification", c => c.Int());
            AddColumn("dbo.QualificationVacancies", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.QualificationVacancies", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.QualificationVacancies", "Qualification_Id", "dbo.Qualifications");
            DropIndex("dbo.QualificationVacancies", new[] { "Vacancy_Id" });
            DropIndex("dbo.QualificationVacancies", new[] { "Qualification_Id" });
            DropPrimaryKey("dbo.QualificationVacancies");
            AddPrimaryKey("dbo.QualificationVacancy", "Id");
            DropColumn("dbo.QualificationVacancies", "Vacancy_Id");
            DropColumn("dbo.QualificationVacancies", "Qualification_Id");
            DropTable("dbo.QualificationVacancies");
            CreateIndex("dbo.QualificationVacancy", "IdQualification");
            CreateIndex("dbo.QualificationVacancy", "IdVacancy");
            AddForeignKey("dbo.QualificationVacancy", "IdQualification", "dbo.Qualifications", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QualificationVacancy", "IdVacancy", "dbo.Vacancies", "Id", cascadeDelete: true);
        }
    }
}
