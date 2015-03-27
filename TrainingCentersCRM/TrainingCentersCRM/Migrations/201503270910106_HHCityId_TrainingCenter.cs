namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HHCityId_TrainingCenter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TrainingCenters", "HHCityId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TrainingCenters", "HHCityId");
        }
    }
}
