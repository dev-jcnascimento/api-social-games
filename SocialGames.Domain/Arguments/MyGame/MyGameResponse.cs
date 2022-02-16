using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class MyGameResponse
    {
        public string Date { get; set; }
        public string PlayerId { get; set; }
        public string GameId { get; set; }
        public string Status { get; set; }

        public static explicit operator MyGameResponse(Entities.MyGame entity)
        {
            return new MyGameResponse()
            {
                Date = entity.Date.ToString(),
                PlayerId = entity.Player.Name.ToString(),
                GameId = entity.Game.Name.ToString(),
                Status = entity.MyGameStatus.ToString(),
            };
        }
    }
}
