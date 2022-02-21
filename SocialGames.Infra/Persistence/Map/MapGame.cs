using SocialGames.Domain.Entities;
using SocialGames.Domain.ValueObject;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapGame : EntityTypeConfiguration<Game>
    {
        public MapGame()
        {
            ToTable("Game");

            HasKey(p => p.Id);
            Property(x => x.Name).IsRequired().HasColumnName("Name").HasMaxLength(100);
            Property(x => x.Description).IsRequired().HasColumnName("Description").HasMaxLength(200);
            Property(x => x.Gender).IsRequired().HasColumnName("Gender").HasMaxLength(100); 
            Property(x => x.Distributor).IsRequired().HasColumnName("Distributor").HasMaxLength(100); 
            Property(x => x.Producer).IsRequired().HasColumnName("Producer").HasMaxLength(100);
            Property(x => x.PlatFormId).IsRequired().HasColumnName("PlatFormId");
            HasMany(x => x.MyGames);
            HasMany(x => x.Comments);
        }
    }
}
