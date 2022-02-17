namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Game", "Name", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Game", "Producer", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Game", "Gender", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Game", "Distributor", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Game", "Distributor", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Game", "Gender", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Game", "Producer", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Game", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
