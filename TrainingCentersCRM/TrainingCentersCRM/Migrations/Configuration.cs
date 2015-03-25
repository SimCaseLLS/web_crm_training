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
