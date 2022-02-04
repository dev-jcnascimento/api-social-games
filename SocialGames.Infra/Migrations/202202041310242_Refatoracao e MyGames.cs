namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefatoracaoeMyGames : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.GamePlatForm", new[] { "PlatFormId" });
            RenameColumn(table: "dbo.GamePlatForm", name: "PlatFormId", newName: "PlatForm_Id");
            CreateTable(
                "dbo.MyGames",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GameStatus = c.Int(name: "Game Status", nullable: false),
                        PlayerId = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.PlayerId)
                .Index(t => t.GameId);
            
            AddColumn("dbo.Game", "PlatFormId", c => c.Guid(nullable: false));
            AddColumn("dbo.Game", "Player_Id", c => c.Guid());
            AddColumn("dbo.PlatForm", "Player_Id", c => c.Guid());
            AlterColumn("dbo.GamePlatForm", "PlatForm_Id", c => c.Guid());
            CreateIndex("dbo.GamePlatForm", "PlatForm_Id");
            CreateIndex("dbo.Game", "PlatFormId");
            CreateIndex("dbo.Game", "Player_Id");
            CreateIndex("dbo.PlatForm", "Player_Id");
            AddForeignKey("dbo.Game", "PlatFormId", "dbo.PlatForm", "Id");
            AddForeignKey("dbo.Game", "Player_Id", "dbo.Player", "Id");
            AddForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyGames", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PlatForm", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.Game", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.MyGames", "GameId", "dbo.Game");
            DropForeignKey("dbo.Game", "PlatFormId", "dbo.PlatForm");
            DropIndex("dbo.MyGames", new[] { "GameId" });
            DropIndex("dbo.MyGames", new[] { "PlayerId" });
            DropIndex("dbo.PlatForm", new[] { "Player_Id" });
            DropIndex("dbo.Game", new[] { "Player_Id" });
            DropIndex("dbo.Game", new[] { "PlatFormId" });
            DropIndex("dbo.GamePlatForm", new[] { "PlatForm_Id" });
            AlterColumn("dbo.GamePlatForm", "PlatForm_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.PlatForm", "Player_Id");
            DropColumn("dbo.Game", "Player_Id");
            DropColumn("dbo.Game", "PlatFormId");
            DropTable("dbo.MyGames");
            RenameColumn(table: "dbo.GamePlatForm", name: "PlatForm_Id", newName: "PlatFormId");
            CreateIndex("dbo.GamePlatForm", "PlatFormId");
        }
    }
}
