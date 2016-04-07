namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Image = c.Binary(),
                        Enabled = c.Boolean(nullable: false),
                        ImageType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Annotation = c.String(maxLength: 1000),
                        Text = c.String(),
                        UserId = c.Int(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        TrainingCenterId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCenters", t => t.TrainingCenterId)
                .Index(t => t.TrainingCenterId);
            
            CreateTable(
                "dbo.TrainingCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Addres = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Organization = c.String(maxLength: 255),
                        Description = c.String(),
                        Logo = c.Binary(storeType: "image"),
                        HHCityId = c.String(),
                        Url = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Email = c.String(nullable: false, maxLength: 250),
                        Message = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IdTrainingCenter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter);
            
            CreateTable(
                "dbo.ScheduleTtrainingCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1023),
                        DateStart = c.DateTime(storeType: "date"),
                        DateEnd = c.DateTime(storeType: "date"),
                        IdTrainingCenter = c.Int(),
                        IdTrainingCourse = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter)
                .Index(t => t.IdTrainingCourse);
            
            CreateTable(
                "dbo.TrainingCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        ShortDescription = c.String(maxLength: 2048),
                        Hourse = c.Int(),
                        PriceForOrganizations = c.Decimal(storeType: "money"),
                        PriceForIndividuals = c.Decimal(storeType: "money"),
                        CostOfOneHourForOrganizations = c.Decimal(storeType: "money"),
                        CostOfOneHourForIndividuals = c.Decimal(storeType: "money"),
                        LevelOfDifficulty = c.Int(),
                        RequiredPreliminaryPreparation = c.String(maxLength: 1023),
                        MandatoryPreliminaryPreparation = c.String(maxLength: 1023),
                        IdObject = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        IdTrainingModule = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingModules", t => t.IdTrainingModule, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .Index(t => t.IdTrainingCourse)
                .Index(t => t.IdTrainingModule);
            
            CreateTable(
                "dbo.TrainingModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        ShortDescription = c.String(maxLength: 1023),
                        Numbers = c.Int(),
                        Hours = c.Int(),
                        Topics = c.Int(),
                        IdTrainingCenter = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HoldCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        IdTrainingGroup = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingGroups", t => t.IdTrainingGroup)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .Index(t => t.IdTrainingCourse)
                .Index(t => t.IdTrainingGroup);
            
            CreateTable(
                "dbo.TrainingGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        EstimateOfExpenditures = c.String(maxLength: 255),
                        IdObject = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Listeners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingGroup = c.Int(),
                        IdCourseTakings = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTakings", t => t.IdCourseTakings, cascadeDelete: true)
                .ForeignKey("dbo.TrainingGroups", t => t.IdTrainingGroup, cascadeDelete: true)
                .Index(t => t.IdTrainingGroup)
                .Index(t => t.IdCourseTakings);
            
            CreateTable(
                "dbo.CourseTakings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdStudent = c.Int(),
                        IdTrainingCourse = c.Int(),
                        Status = c.Int(),
                        AmountPaid = c.Decimal(storeType: "money"),
                        Debt = c.Decimal(storeType: "money"),
                        Description = c.String(maxLength: 1023),
                        IdObecjt = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QualificationTrainingCours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQualification = c.Int(),
                        IdTrainingCours = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualifications", t => t.IdQualification, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCours, cascadeDelete: true)
                .Index(t => t.IdQualification)
                .Index(t => t.IdTrainingCours);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                        Type = c.Int(),
                        HeadHunterId = c.String(maxLength: 255),
                        HeadHunterName = c.String(maxLength: 1023),
                        HeadHunterKeys = c.String(maxLength: 1023),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QualificationCertification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQualification = c.Int(),
                        IdCertification = c.Int(),
                        Qualifications_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certifications", t => t.IdCertification, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.Qualifications_Id)
                .ForeignKey("dbo.Qualifications", t => t.IdQualification, cascadeDelete: true)
                .Index(t => t.IdQualification)
                .Index(t => t.IdCertification)
                .Index(t => t.Qualifications_Id);
            
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdProvider = c.Int(),
                        Title = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CertificationProviders", t => t.IdProvider)
                .Index(t => t.IdProvider);
            
            CreateTable(
                "dbo.CertificationProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Addres = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacancies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1023),
                        Organization = c.String(maxLength: 255),
                        Wages = c.Decimal(storeType: "money"),
                        Additionally = c.String(maxLength: 1023),
                        Link = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingCenterCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCenter = c.Int(),
                        IdTrainingCourse = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter)
                .Index(t => t.IdTrainingCourse);
            
            CreateTable(
                "dbo.RelatedCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourseRelated = c.Int(),
                        TrainingCours_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCenterCourses", t => t.TrainingCours_Id)
                .ForeignKey("dbo.TrainingCenterCourses", t => t.IdTrainingCourseRelated, cascadeDelete: true)
                .Index(t => t.IdTrainingCourseRelated)
                .Index(t => t.TrainingCours_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        Patronymic = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                        Phone = c.String(maxLength: 255),
                        Image = c.Binary(),
                        DateOfBirth = c.Int(),
                        PassportData = c.String(maxLength: 255),
                        IdObject = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        TrainingCenterCours_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCenterCourses", t => t.TrainingCenterCours_Id)
                .Index(t => t.TrainingCenterCours_Id);
            
            CreateTable(
                "dbo.TrainingCenterTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCenter = c.Int(),
                        IdTeacher = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdTeacher, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter)
                .Index(t => t.IdTeacher);
            
            CreateTable(
                "dbo.TrainingCourseTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        IdTeacher = c.Int(),
                        TrainingCours_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCenterCourses", t => t.TrainingCours_Id)
                .ForeignKey("dbo.Users", t => t.IdTeacher, cascadeDelete: true)
                .Index(t => t.IdTeacher)
                .Index(t => t.TrainingCours_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CertificationTakings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdStudent = c.Int(),
                        IdCertification = c.Int(),
                        Date = c.Int(),
                        Result = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.Int(),
                        Duration = c.Int(),
                        IdObject = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        NotBindInTrainingCenter = c.Boolean(nullable: false),
                        IdTrainingCenter = c.String(),
                        Parent_Id = c.Int(nullable: false),
                        Ord_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.Articles", "TrainingCenterId", "dbo.TrainingCenters");
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.TrainingCenterCourses", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.ScheduleTtrainingCourses", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.TrainingCenterCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.Users", "TrainingCenterCours_Id", "dbo.TrainingCenterCourses");
            DropForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Users");
            DropForeignKey("dbo.TrainingCourseTeachers", "TrainingCours_Id", "dbo.TrainingCenterCourses");
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Users");
            DropForeignKey("dbo.RelatedCourses", "IdTrainingCourseRelated", "dbo.TrainingCenterCourses");
            DropForeignKey("dbo.RelatedCourses", "TrainingCours_Id", "dbo.TrainingCenterCourses");
            DropForeignKey("dbo.ScheduleTtrainingCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.QualificationTrainingCours", "IdTrainingCours", "dbo.TrainingCourses");
            DropForeignKey("dbo.QualificationVacancies", "Vacancy_Id", "dbo.Vacancies");
            DropForeignKey("dbo.QualificationVacancies", "Qualification_Id", "dbo.Qualifications");
            DropForeignKey("dbo.QualificationTrainingCours", "IdQualification", "dbo.Qualifications");
            DropForeignKey("dbo.QualificationCertification", "IdQualification", "dbo.Qualifications");
            DropForeignKey("dbo.QualificationCertification", "Qualifications_Id", "dbo.Qualifications");
            DropForeignKey("dbo.QualificationCertification", "IdCertification", "dbo.Certifications");
            DropForeignKey("dbo.Certifications", "IdProvider", "dbo.CertificationProviders");
            DropForeignKey("dbo.HoldCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.Listeners", "IdTrainingGroup", "dbo.TrainingGroups");
            DropForeignKey("dbo.Listeners", "IdCourseTakings", "dbo.CourseTakings");
            DropForeignKey("dbo.HoldCourses", "IdTrainingGroup", "dbo.TrainingGroups");
            DropForeignKey("dbo.CourseModules", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.CourseModules", "IdTrainingModule", "dbo.TrainingModules");
            DropForeignKey("dbo.Feedbacks", "IdTrainingCenter", "dbo.TrainingCenters");
            DropIndex("dbo.QualificationVacancies", new[] { "Vacancy_Id" });
            DropIndex("dbo.QualificationVacancies", new[] { "Qualification_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserId" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "TrainingCours_Id" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTrainingCenter" });
            DropIndex("dbo.Users", new[] { "TrainingCenterCours_Id" });
            DropIndex("dbo.RelatedCourses", new[] { "TrainingCours_Id" });
            DropIndex("dbo.RelatedCourses", new[] { "IdTrainingCourseRelated" });
            DropIndex("dbo.TrainingCenterCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.TrainingCenterCourses", new[] { "IdTrainingCenter" });
            DropIndex("dbo.Certifications", new[] { "IdProvider" });
            DropIndex("dbo.QualificationCertification", new[] { "Qualifications_Id" });
            DropIndex("dbo.QualificationCertification", new[] { "IdCertification" });
            DropIndex("dbo.QualificationCertification", new[] { "IdQualification" });
            DropIndex("dbo.QualificationTrainingCours", new[] { "IdTrainingCours" });
            DropIndex("dbo.QualificationTrainingCours", new[] { "IdQualification" });
            DropIndex("dbo.Listeners", new[] { "IdCourseTakings" });
            DropIndex("dbo.Listeners", new[] { "IdTrainingGroup" });
            DropIndex("dbo.HoldCourses", new[] { "IdTrainingGroup" });
            DropIndex("dbo.HoldCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.CourseModules", new[] { "IdTrainingModule" });
            DropIndex("dbo.CourseModules", new[] { "IdTrainingCourse" });
            DropIndex("dbo.ScheduleTtrainingCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.ScheduleTtrainingCourses", new[] { "IdTrainingCenter" });
            DropIndex("dbo.Feedbacks", new[] { "IdTrainingCenter" });
            DropIndex("dbo.Articles", new[] { "TrainingCenterId" });
            DropTable("dbo.QualificationVacancies");
            DropTable("dbo.Menus");
            DropTable("dbo.Lessons");
            DropTable("dbo.CertificationTakings");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TrainingCourseTeachers");
            DropTable("dbo.TrainingCenterTeachers");
            DropTable("dbo.Users");
            DropTable("dbo.RelatedCourses");
            DropTable("dbo.TrainingCenterCourses");
            DropTable("dbo.Vacancies");
            DropTable("dbo.CertificationProviders");
            DropTable("dbo.Certifications");
            DropTable("dbo.QualificationCertification");
            DropTable("dbo.Qualifications");
            DropTable("dbo.QualificationTrainingCours");
            DropTable("dbo.CourseTakings");
            DropTable("dbo.Listeners");
            DropTable("dbo.TrainingGroups");
            DropTable("dbo.HoldCourses");
            DropTable("dbo.TrainingModules");
            DropTable("dbo.CourseModules");
            DropTable("dbo.TrainingCourses");
            DropTable("dbo.ScheduleTtrainingCourses");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.TrainingCenters");
            DropTable("dbo.Articles");
            DropTable("dbo.Advertizes");
        }
    }
}
