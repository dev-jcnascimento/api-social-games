using SocialGames.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapPlatForm : EntityTypeConfiguration<PlatForm>
    {
        public MapPlatForm()
        {
            ToTable("PlatForm");

            HasKey(p => p.Id);
            Property(p => p.Name).HasMaxLength(50).IsRequired().HasColumnName("Name");
            HasMany(x => x.Games);
        }
    }
}
