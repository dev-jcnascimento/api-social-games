using SocialGames.Domain.Arguments.PlatForm;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class PlayerPlatformsResponse
    {
        public Guid PlatformId { get; set; }
        public string Platform { get; set; }

        public static explicit operator PlayerPlatformsResponse(Entities.PlatForm entity)
        {
            return new PlayerPlatformsResponse()
            {
                PlatformId = entity.Id,
                Platform = entity.Name
            };
        }

        public static explicit operator PlayerPlatformsResponse(PlatFormResponse entity)
        {
            return new PlayerPlatformsResponse()
            {
                PlatformId = entity.Id,
                Platform = entity.Name
            };
        }
    }
}
