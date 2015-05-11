namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainingCenterLogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCenters", "LogoContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingCenters", "LogoContentType");
        }
    }
}
