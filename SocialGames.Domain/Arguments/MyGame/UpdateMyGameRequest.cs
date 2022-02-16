using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class UpdateMyGameRequest
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string MyStatusGame { get; set; }
    }
}
