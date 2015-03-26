namespace TrainingCentersCRM.Migrations
{
    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TrainingCentersCRM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainingCentersCRM.Models.TrainingCentersDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrainingCentersCRM.Models.TrainingCentersDBEntities db)
        {
            db.TrainingCenters.AddOrUpdate(
                p => p.Url,
                new TrainingCenter { Url = "ulstu", Organization = "�����" },
                new TrainingCenter { Url = "empty" }
            );
            db.Menu.AddOrUpdate(
                p => new { p.Title, p.IdTrainingCenter},
                    new Menu { Title = "�����", Link = "/TrainingCours/Index", Parent_Id = 0, IdTrainingCenter = "other", Ord_Id = 1 },
                    new Menu { Title = "� �������", Link = "/Home/About", Parent_Id = 0, IdTrainingCenter = "empty", Ord_Id = 1 }
                );
            // ������������
            db.Qualifications.AddOrUpdate(
                p => p.Title,
                    new Qualification { Title = "����������������", Description = "������������, ��������� � �����������������", ParentId = 0, Id = 1 },
                    new Qualification { Title = "���������", Description = "������������, ��������� � ����������", ParentId = 0, Id = 2 },
                    new Qualification { Title = "���������", Description = "������������, ��������� � ����������", ParentId = 0, Id = 3 }
                );
            var progId = db.Qualifications.Where(q => q.Title == "����������������").First().Id;
            var econId = db.Qualifications.Where(q => q.Title == "���������").First().Id;
            var engId = db.Qualifications.Where(q => q.Title == "���������").First().Id;
            db.Qualifications.AddOrUpdate(
                p => p.Title,
                    new Qualification { Title = "Java �����������", Description = "������� �� ����� Java", HeadHunterId = "1.221", HeadHunterKeys = "Java", HeadHunterName = "����������������, ����������", ParentId = progId },
                    new Qualification { Title = "C# �����������", Description = "������� �� ����� C#", HeadHunterId = "1.221", HeadHunterKeys = "C#", HeadHunterName = "����������������, ����������", ParentId = progId },
                    new Qualification { Title = "DBA", Description = "���������� ��� ������", HeadHunterId = "1.221", HeadHunterKeys = "DBA,���� ������", HeadHunterName = "����������������, ����������", ParentId = progId },
                    
                    new Qualification { Title = "���������", Description = "����� � ���������", HeadHunterId = "2.425", HeadHunterKeys = "", HeadHunterName = "���������", ParentId = econId },

                    new Qualification { Title = "�������-�����������", Description = "����� � ������������", HeadHunterId = "18.57", HeadHunterKeys = "������������", HeadHunterName = "������� �������", ParentId = engId }
                );

            db.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
