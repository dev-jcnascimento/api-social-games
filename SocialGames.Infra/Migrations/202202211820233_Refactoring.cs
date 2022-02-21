namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameComment",
                c => new
                    {
                        Game_Id = c.Guid(nullable: false),
                        Comment_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.Comment_Id })
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.PlayerComment",
                c => new
                    {
                        Player_Id = c.Guid(nullable: false),
                        Comment_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Comment_Id })
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.PlayerMyGame",
                c => new
                    {
                        Player_Id = c.Guid(nullable: false),
                        MyGame_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.MyGame_Id })
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .ForeignKey("dbo.MyGames", t => t.MyGame_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.MyGame_Id);
            
            CreateTable(
                "dbo.GameMyGame",
                c => new
                    {
                        Game_Id = c.Guid(nullable: false),
                        MyGame_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.MyGame_Id })
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .ForeignKey("dbo.MyGames", t => t.MyGame_Id)
                .Index(t => t.Game_Id)
                .Index(t => t.MyGame_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameMyGame", "MyGame_Id", "dbo.MyGames");
            DropForeignKey("dbo.GameMyGame", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.PlayerMyGame", "MyGame_Id", "dbo.MyGames");
            DropForeignKey("dbo.PlayerMyGame", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.PlayerComment", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.PlayerComment", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.GameComment", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.GameComment", "Game_Id", "dbo.Game");
            DropIndex("dbo.GameMyGame", new[] { "MyGame_Id" });
            DropIndex("dbo.GameMyGame", new[] { "Game_Id" });
            DropIndex("dbo.PlayerMyGame", new[] { "MyGame_Id" });
            DropIndex("dbo.PlayerMyGame", new[] { "Player_Id" });
            DropIndex("dbo.PlayerComment", new[] { "Comment_Id" });
            DropIndex("dbo.PlayerComment", new[] { "Player_Id" });
            DropIndex("dbo.GameComment", new[] { "Comment_Id" });
            DropIndex("dbo.GameComment", new[] { "Game_Id" });
            DropTable("dbo.GameMyGame");
            DropTable("dbo.PlayerMyGame");
            DropTable("dbo.PlayerComment");
            DropTable("dbo.GameComment");
        }
    }
}
