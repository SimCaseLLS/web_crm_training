namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyToAspNetUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "AspNetUserId", c => c.String());
            CreateIndex("dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Email");
        }
        
        public override void Down()
        { 
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "UserId" });
            DropColumn("dbo.Users", "AspNetUserId");
            DropColumn("dbo.AspNetUsers", "UserId");
            DropColumn("dbo.AspNetUsers", "UserId");
        }
    }
}
