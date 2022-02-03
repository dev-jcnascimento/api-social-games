using System;

namespace SocialGames.Domain.Arguments.GamePlatForm
{
    public class CreateGamePlatFormRequest
    {
        public Guid GameId { get; set; }
        public Guid PlatFormId { get; set; }
    }
}
