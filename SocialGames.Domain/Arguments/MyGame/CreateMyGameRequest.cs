using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class CreateMyGameRequest
    {
        public Guid PlayerId { get;  set; }
        public Guid GameId { get;  set; }
    }
}
