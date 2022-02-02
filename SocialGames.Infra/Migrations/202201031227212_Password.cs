namespace SocialGames.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Password : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Player", name: "Password_Word", newName: "Password");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Player", name: "Password", newName: "Password_Word");
        }
    }
}
