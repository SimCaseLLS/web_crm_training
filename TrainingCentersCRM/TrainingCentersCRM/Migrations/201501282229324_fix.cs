namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
    }
}
