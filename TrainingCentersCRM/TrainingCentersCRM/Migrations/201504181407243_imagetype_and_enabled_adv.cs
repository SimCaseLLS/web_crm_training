namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagetype_and_enabled_adv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Advertizes", "Enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Advertizes", "ImageType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Advertizes", "ImageType");
            DropColumn("dbo.Advertizes", "Enabled");
        }
    }
}
