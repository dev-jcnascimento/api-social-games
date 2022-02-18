using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class MyGameResponse
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string PlayerName { get; set; }
        public string GameName { get; set; }
        public string StatusGame { get; set; }
        public string PlatformName { get; set; }

        public static explicit operator MyGameResponse(Entities.MyGame entity)
        {
            return new MyGameResponse()
            {
                Id = entity.Id,
                Date = entity.Date.ToString(),
                PlayerName = entity.Player.Name.ToString(),
                GameName = entity.Game.Name,
                StatusGame = entity.MyGameStatus.ToString(),
                PlatformName = entity.Game.PlatFormId.ToString(),

            };
        }
    }
}
