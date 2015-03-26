namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_not_bind_in_tc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "NotBindInTrainingCenter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "NotBindInTrainingCenter");
        }
    }
}
