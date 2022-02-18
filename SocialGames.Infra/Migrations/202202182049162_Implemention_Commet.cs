namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implemention_Commet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                        MyGameId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MyGames", t => t.MyGameId)
                .Index(t => t.MyGameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "MyGameId", "dbo.MyGames");
            DropIndex("dbo.Comment", new[] { "MyGameId" });
            DropTable("dbo.Comment");
        }
    }
}
