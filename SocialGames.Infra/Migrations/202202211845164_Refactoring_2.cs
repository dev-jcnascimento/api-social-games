namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameComment", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.GameComment", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.PlayerComment", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.PlayerComment", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.PlayerMyGame", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.PlayerMyGame", "MyGame_Id", "dbo.MyGames");
            DropForeignKey("dbo.GameMyGame", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.GameMyGame", "MyGame_Id", "dbo.MyGames");
            DropIndex("dbo.GameComment", new[] { "Game_Id" });
            DropIndex("dbo.GameComment", new[] { "Comment_Id" });
            DropIndex("dbo.PlayerComment", new[] { "Player_Id" });
            DropIndex("dbo.PlayerComment", new[] { "Comment_Id" });
            DropIndex("dbo.PlayerMyGame", new[] { "Player_Id" });
            DropIndex("dbo.PlayerMyGame", new[] { "MyGame_Id" });
            DropIndex("dbo.GameMyGame", new[] { "Game_Id" });
            DropIndex("dbo.GameMyGame", new[] { "MyGame_Id" });
            DropTable("dbo.GameComment");
            DropTable("dbo.PlayerComment");
            DropTable("dbo.PlayerMyGame");
            DropTable("dbo.GameMyGame");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameMyGame",
                c => new
                    {
                        Game_Id = c.Guid(nullable: false),
                        MyGame_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.MyGame_Id });
            
            CreateTable(
                "dbo.PlayerMyGame",
                c => new
                    {
                        Player_Id = c.Guid(nullable: false),
                        MyGame_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.MyGame_Id });
            
            CreateTable(
                "dbo.PlayerComment",
                c => new
                    {
                        Player_Id = c.Guid(nullable: false),
                        Comment_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Comment_Id });
            
            CreateTable(
                "dbo.GameComment",
                c => new
                    {
                        Game_Id = c.Guid(nullable: false),
                        Comment_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Game_Id, t.Comment_Id });
            
            CreateIndex("dbo.GameMyGame", "MyGame_Id");
            CreateIndex("dbo.GameMyGame", "Game_Id");
            CreateIndex("dbo.PlayerMyGame", "MyGame_Id");
            CreateIndex("dbo.PlayerMyGame", "Player_Id");
            CreateIndex("dbo.PlayerComment", "Comment_Id");
            CreateIndex("dbo.PlayerComment", "Player_Id");
            CreateIndex("dbo.GameComment", "Comment_Id");
            CreateIndex("dbo.GameComment", "Game_Id");
            AddForeignKey("dbo.GameMyGame", "MyGame_Id", "dbo.MyGames", "Id");
            AddForeignKey("dbo.GameMyGame", "Game_Id", "dbo.Game", "Id");
            AddForeignKey("dbo.PlayerMyGame", "MyGame_Id", "dbo.MyGames", "Id");
            AddForeignKey("dbo.PlayerMyGame", "Player_Id", "dbo.Player", "Id");
            AddForeignKey("dbo.PlayerComment", "Comment_Id", "dbo.Comment", "Id");
            AddForeignKey("dbo.PlayerComment", "Player_Id", "dbo.Player", "Id");
            AddForeignKey("dbo.GameComment", "Comment_Id", "dbo.Comment", "Id");
            AddForeignKey("dbo.GameComment", "Game_Id", "dbo.Game", "Id");
        }
    }
}
