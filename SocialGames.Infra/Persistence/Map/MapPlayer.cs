using SocialGames.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapPlayer : EntityTypeConfiguration<Player>
    {
        public MapPlayer()
        {
            ToTable("Player");

            HasKey(p => p.Id);
            Property(p => p.Email.Address).HasMaxLength(200).IsRequired().HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_PLAYER_EMAIL") { IsUnique = true })).HasColumnName("Email");
            Property(p => p.Name.FirstName).HasMaxLength(50).IsRequired().HasColumnName("FirstName");
            Property(p => p.Name.LastName).HasMaxLength(50).IsRequired().HasColumnName("LastName");
            Property(p => p.Password.Word).HasColumnName("Password").IsRequired();
            Property(p => p.Status).IsRequired();
            HasMany(x => x.MyGames);
        }
    }
}
