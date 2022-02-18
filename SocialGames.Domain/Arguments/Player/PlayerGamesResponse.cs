using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class PlayerGamesResponse
    {
        public Guid GameId { get; set; }
        public string Game { get; set; }
        public string StatusGame { get; set; }
        public Guid PlatformId { get; set; }
        public string Platform { get; set; }

        public static explicit operator PlayerGamesResponse(Entities.Game v)
        {
            throw new NotImplementedException();
        }
    }
}
