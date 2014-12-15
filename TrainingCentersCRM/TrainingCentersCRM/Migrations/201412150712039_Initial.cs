namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.QualificationCertification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQualification = c.Int(),
                        IdCertification = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualifications", t => t.IdQualification, cascadeDelete: true)
                .ForeignKey("dbo.Certifications", t => t.IdCertification, cascadeDelete: true)
                .Index(t => t.IdQualification)
                .Index(t => t.IdCertification);
            
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                        Type = c.Int(),
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
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCours, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.IdQualification, cascadeDelete: true)
                .Index(t => t.IdTrainingCours)
                .Index(t => t.IdQualification);
            
            CreateTable(
                "dbo.TrainingCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        ShortDescription = c.String(maxLength: 1023),
                        Hourse = c.Int(),
                        PriceForOrganizations = c.Decimal(storeType: "money"),
                        PriceForIndividuals = c.Decimal(storeType: "money"),
                        CostOfOneHourForOrganizations = c.Decimal(storeType: "money"),
                        CostOfOneHourForIndividuals = c.Decimal(storeType: "money"),
                        LevelOfDifficulty = c.Int(),
                        RequiredPreliminaryPreparation = c.String(maxLength: 1023),
                        MandatoryPreliminaryPreparation = c.String(maxLength: 1023),
                        IdTraningCenter = c.Int(),
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
                .Index(t => t.IdTrainingModule)
                .Index(t => t.IdTrainingCourse);
            
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
                .Index(t => t.IdTrainingGroup)
                .Index(t => t.IdTrainingCourse);
            
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
                .Index(t => t.IdCourseTakings)
                .Index(t => t.IdTrainingGroup);
            
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
                "dbo.RelatedCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        IdTrainingCourseRelated = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourseRelated)
                .Index(t => t.IdTrainingCourse)
                .Index(t => t.IdTrainingCourseRelated);
            
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
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter)
                .Index(t => t.IdTrainingCourse);
            
            CreateTable(
                "dbo.TrainingCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Addres = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Organization = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                        Logo = c.Binary(storeType: "image"),
                        Url = c.String(nullable: false, maxLength: 255),
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
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .Index(t => t.IdTrainingCenter)
                .Index(t => t.IdTrainingCourse);
            
            CreateTable(
                "dbo.TrainingCenterTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCenter = c.Int(),
                        IdTeacher = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCenters", t => t.IdTrainingCenter, cascadeDelete: true)
                .Index(t => t.IdTeacher)
                .Index(t => t.IdTrainingCenter);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        Patronymic = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrainingCourseTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdTrainingCourse = c.Int(),
                        IdTeacher = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.IdTeacher, cascadeDelete: true)
                .ForeignKey("dbo.TrainingCourses", t => t.IdTrainingCourse, cascadeDelete: true)
                .Index(t => t.IdTeacher)
                .Index(t => t.IdTrainingCourse);
            
            CreateTable(
                "dbo.QualificationVacancy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdQualification = c.Int(),
                        IdVacancy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vacancies", t => t.IdVacancy, cascadeDelete: true)
                .ForeignKey("dbo.Qualifications", t => t.IdQualification, cascadeDelete: true)
                .Index(t => t.IdVacancy)
                .Index(t => t.IdQualification);
            
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
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 255),
                        FirstName = c.String(maxLength: 255),
                        Patronymic = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        DateOfBirth = c.Int(),
                        PassportData = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1023),
                        IdObject = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certifications", "IdProvider", "dbo.CertificationProviders");
            DropForeignKey("dbo.QualificationCertification", "IdCertification", "dbo.Certifications");
            DropForeignKey("dbo.QualificationVacancy", "IdQualification", "dbo.Qualifications");
            DropForeignKey("dbo.QualificationVacancy", "IdVacancy", "dbo.Vacancies");
            DropForeignKey("dbo.QualificationTrainingCours", "IdQualification", "dbo.Qualifications");
            DropForeignKey("dbo.TrainingCourseTeachers", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.TrainingCenterCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.ScheduleTtrainingCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.TrainingCenterCourses", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.ScheduleTtrainingCourses", "IdTrainingCenter", "dbo.TrainingCenters");
            DropForeignKey("dbo.RelatedCourses", "IdTrainingCourseRelated", "dbo.TrainingCourses");
            DropForeignKey("dbo.RelatedCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.QualificationTrainingCours", "IdTrainingCours", "dbo.TrainingCourses");
            DropForeignKey("dbo.HoldCourses", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.Listeners", "IdTrainingGroup", "dbo.TrainingGroups");
            DropForeignKey("dbo.Listeners", "IdCourseTakings", "dbo.CourseTakings");
            DropForeignKey("dbo.HoldCourses", "IdTrainingGroup", "dbo.TrainingGroups");
            DropForeignKey("dbo.CourseModules", "IdTrainingCourse", "dbo.TrainingCourses");
            DropForeignKey("dbo.CourseModules", "IdTrainingModule", "dbo.TrainingModules");
            DropForeignKey("dbo.QualificationCertification", "IdQualification", "dbo.Qualifications");
            DropIndex("dbo.Certifications", new[] { "IdProvider" });
            DropIndex("dbo.QualificationCertification", new[] { "IdCertification" });
            DropIndex("dbo.QualificationVacancy", new[] { "IdQualification" });
            DropIndex("dbo.QualificationVacancy", new[] { "IdVacancy" });
            DropIndex("dbo.QualificationTrainingCours", new[] { "IdQualification" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "IdTrainingCourse" });
            DropIndex("dbo.TrainingCenterCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.ScheduleTtrainingCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTrainingCenter" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCenterCourses", new[] { "IdTrainingCenter" });
            DropIndex("dbo.ScheduleTtrainingCourses", new[] { "IdTrainingCenter" });
            DropIndex("dbo.RelatedCourses", new[] { "IdTrainingCourseRelated" });
            DropIndex("dbo.RelatedCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.QualificationTrainingCours", new[] { "IdTrainingCours" });
            DropIndex("dbo.HoldCourses", new[] { "IdTrainingCourse" });
            DropIndex("dbo.Listeners", new[] { "IdTrainingGroup" });
            DropIndex("dbo.Listeners", new[] { "IdCourseTakings" });
            DropIndex("dbo.HoldCourses", new[] { "IdTrainingGroup" });
            DropIndex("dbo.CourseModules", new[] { "IdTrainingCourse" });
            DropIndex("dbo.CourseModules", new[] { "IdTrainingModule" });
            DropIndex("dbo.QualificationCertification", new[] { "IdQualification" });
            DropTable("dbo.Students");
            DropTable("dbo.Lessons");
            DropTable("dbo.CertificationTakings");
            DropTable("dbo.Vacancies");
            DropTable("dbo.QualificationVacancy");
            DropTable("dbo.TrainingCourseTeachers");
            DropTable("dbo.Teachers");
            DropTable("dbo.TrainingCenterTeachers");
            DropTable("dbo.TrainingCenterCourses");
            DropTable("dbo.TrainingCenters");
            DropTable("dbo.ScheduleTtrainingCourses");
            DropTable("dbo.RelatedCourses");
            DropTable("dbo.CourseTakings");
            DropTable("dbo.Listeners");
            DropTable("dbo.TrainingGroups");
            DropTable("dbo.HoldCourses");
            DropTable("dbo.TrainingModules");
            DropTable("dbo.CourseModules");
            DropTable("dbo.TrainingCourses");
            DropTable("dbo.QualificationTrainingCours");
            DropTable("dbo.Qualifications");
            DropTable("dbo.QualificationCertification");
            DropTable("dbo.Certifications");
            DropTable("dbo.CertificationProviders");
            DropTable("dbo.AspNetUsers");
        }
    }
}
