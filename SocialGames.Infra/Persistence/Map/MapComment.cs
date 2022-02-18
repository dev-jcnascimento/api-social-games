using SocialGames.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapComment : EntityTypeConfiguration<Comment>
    {
        public MapComment()
        {
            ToTable("Comment");

            HasKey(p => p.Id);
            Property(x => x.DateTime).IsRequired().HasColumnName("Date");
            Property(x => x.Description).IsRequired().HasColumnName("Description").HasMaxLength(500);
            Property(x => x.MyGameId).IsRequired().HasColumnName("MyGameId");
        }
    }
}
