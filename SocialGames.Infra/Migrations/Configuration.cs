namespace SocialGames.Infra.Migrations
{
    using SocialGames.Infra.Persistence;
    using System.Data.Entity.Migrations;
    using System.Linq;

     internal sealed class Configuration : DbMigrationsConfiguration<SocialGames.Infra.Persistence.SocialGamesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SocialGames.Infra.Persistence.SocialGamesContext context)
        {
            
        }
    }
}
