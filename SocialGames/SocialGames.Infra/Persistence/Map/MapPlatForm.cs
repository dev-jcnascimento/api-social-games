using SocialGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapPlatForm : EntityTypeConfiguration<PlatForm>
    {
        public MapPlatForm()
        {
            ToTable("PlatForm");

            Property(p => p.Name).HasMaxLength(50).IsRequired().HasColumnName("Name");
        }
    }
}
