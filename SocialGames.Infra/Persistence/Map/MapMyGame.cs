using SocialGames.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapMyGame : EntityTypeConfiguration<MyGame>
    {
        public MapMyGame()
        {
            ToTable("MyGames");

            HasKey(x => x.Id);
            Property(x => x.Date).IsRequired().HasColumnName("Date");
            Property(x => x.MyGameStatus).IsRequired().HasColumnName("Game Status");
            Property(x => x.PlayerId).IsRequired().HasColumnName("PlayerId");
            Property(x => x.GameId).IsRequired().HasColumnName("GameId");
        }
    }
}
