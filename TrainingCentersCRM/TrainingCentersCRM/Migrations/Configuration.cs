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
                new TrainingCenter { Url = "ulstu", Organization = "УлГТУ" },
                new TrainingCenter { Url = "empty" }
            );
            db.Menu.AddOrUpdate(
                p => new { p.Title, p.IdTrainingCenter},
                    new Menu { Title = "Курсы", Link = "/TrainingCours/Index", Parent_Id = 0, IdTrainingCenter = "other", Ord_Id = 1 },
                    new Menu { Title = "О проекте", Link = "/Home/About", Parent_Id = 0, IdTrainingCenter = "empty", Ord_Id = 1 }
                );
            // Квалификации
            db.Qualifications.AddOrUpdate(
                p => p.Title,
                    new Qualification { Title = "Программирование", Description = "Квалификации, связанные с программированием", ParentId = 0, Id = 1 },
                    new Qualification { Title = "Экономика", Description = "Квалификации, связанные с экономикой", ParentId = 0, Id = 2 },
                    new Qualification { Title = "Инженерия", Description = "Квалификации, связанные с инженерией", ParentId = 0, Id = 3 }
                );
            var progId = db.Qualifications.Where(q => q.Title == "Программирование").First().Id;
            var econId = db.Qualifications.Where(q => q.Title == "Экономика").First().Id;
            var engId = db.Qualifications.Where(q => q.Title == "Инженерия").First().Id;
            db.Qualifications.AddOrUpdate(
                p => p.Title,
                    new Qualification { Title = "Java программист", Description = "Инженер на языке Java", HeadHunterId = "1.221", HeadHunterKeys = "Java", HeadHunterName = "Программирование, Разработка", ParentId = progId },
                    new Qualification { Title = "C# программист", Description = "Инженер на языке C#", HeadHunterId = "1.221", HeadHunterKeys = "C#", HeadHunterName = "Программирование, Разработка", ParentId = progId },
                    new Qualification { Title = "DBA", Description = "Архитектор баз данных", HeadHunterId = "1.221", HeadHunterKeys = "DBA,Базы данных", HeadHunterName = "Программирование, Разработка", ParentId = progId },
                    
                    new Qualification { Title = "Экономист", Description = "Может в экономику", HeadHunterId = "2.425", HeadHunterKeys = "", HeadHunterName = "Экономист", ParentId = econId },

                    new Qualification { Title = "Инженер-Схемотехник", Description = "Может в схемотехнику", HeadHunterId = "18.57", HeadHunterKeys = "Схемотехника", HeadHunterName = "Главный инженер", ParentId = engId }
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
