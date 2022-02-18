using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class MyGameResponse
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string Player { get; set; }
        public string Game { get; set; }
        public string Status { get; set; }

        public static explicit operator MyGameResponse(Entities.MyGame entity)
        {
            return new MyGameResponse()
            {
                Id = entity.Id,
                Date = entity.Date.ToString(),
                Player = entity.Player.Name.ToString(),
                Game = entity.Game.Name.ToString(),
                Status = entity.MyGameStatus.ToString(),
            };
        }
    }
}
