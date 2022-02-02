using SocialGames.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SocialGames.Infra.Persistence.Map
{
    public class MapGamePlatForm : EntityTypeConfiguration<GamePlatForm>
    {
        public MapGamePlatForm()
        {
            ToTable("GamePlatForm");

        }

    }
}
