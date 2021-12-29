namespace SocialGames.Infra.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PlatForm : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlatForm",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlatForm");
        }
    }
}
