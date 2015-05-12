namespace TrainingCentersCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAspNetUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "UserId" });
            AddColumn("dbo.Users", "AspNetUserId", c => c.String());
            DropTable("dbo.AspNetUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropColumn("dbo.Users", "AspNetUserId");
            CreateIndex("dbo.AspNetUsers", "UserId");
            AddForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users", "Id");
        }
    }
}
