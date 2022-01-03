namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreçãodeProp : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GamePlatForm", new[] { "Platform_Id" });
            CreateIndex("dbo.GamePlatForm", "PlatForm_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GamePlatForm", new[] { "PlatForm_Id" });
            CreateIndex("dbo.GamePlatForm", "Platform_Id");
        }
    }
}
