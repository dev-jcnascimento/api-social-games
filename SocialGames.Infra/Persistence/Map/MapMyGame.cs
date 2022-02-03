using SocialGames.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapMyGame : EntityTypeConfiguration<MyGame>
    {
        public MapMyGame()
        {
            ToTable("MyGame");

           
        }
    
    }
}
