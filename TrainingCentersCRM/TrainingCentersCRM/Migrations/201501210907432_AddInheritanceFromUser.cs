namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddInheritanceFromUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Teachers");
            DropForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Teachers");
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "IdTeacher" });
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
                    DateOfBirth = c.Int(),
                    PassportData = c.String(maxLength: 255),
                    IdObject = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Users", "Id", cascadeDelete: true);
            CreateIndex("dbo.TrainingCenterTeachers", "IdTeacher");
            CreateIndex("dbo.TrainingCourseTeachers", "IdTeacher");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
        }

        public override void Down()
        {
            DropForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Users");
            DropForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Users");
            DropIndex("dbo.TrainingCenterTeachers", new[] { "IdTeacher" });
            DropIndex("dbo.TrainingCourseTeachers", new[] { "IdTeacher" });
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
            AddForeignKey("dbo.TrainingCenterTeachers", "IdTeacher", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TrainingCourseTeachers", "IdTeacher", "dbo.Teachers", "Id", cascadeDelete: true);
            CreateIndex("dbo.TrainingCenterTeachers", "IdTeacher");
            CreateIndex("dbo.TrainingCourseTeachers", "IdTeacher");
            DropTable("dbo.Users");
        }
    }
}
