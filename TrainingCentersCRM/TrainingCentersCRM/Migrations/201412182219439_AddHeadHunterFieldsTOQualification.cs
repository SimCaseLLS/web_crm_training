namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeadHunterFieldsTOQualification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qualifications", "HeadHunterId", c => c.String(maxLength: 255));
            AddColumn("dbo.Qualifications", "HeadHunterName", c => c.String(maxLength: 1023));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Qualifications", "HeadHunterName");
            DropColumn("dbo.Qualifications", "HeadHunterId");
        }
    }
}
