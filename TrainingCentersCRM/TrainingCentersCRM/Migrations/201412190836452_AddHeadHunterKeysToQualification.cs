namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeadHunterKeysToQualification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Qualifications", "HeadHunterKeys", c => c.String(maxLength: 1023));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Qualifications", "HeadHunterKeys");
        }
    }
}
