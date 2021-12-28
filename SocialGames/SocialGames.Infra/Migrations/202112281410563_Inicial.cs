namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Name_LastName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Producer = c.String(maxLength: 100, unicode: false),
                        Gender = c.String(maxLength: 100, unicode: false),
                        Distributor = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Password_Word = c.String(nullable: false, maxLength: 100, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true, name: "UK_PLAYER_EMAIL");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Player", "UK_PLAYER_EMAIL");
            DropTable("dbo.Player");
            DropTable("dbo.Game");
        }
    }
}
