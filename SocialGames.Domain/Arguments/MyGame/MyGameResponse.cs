using System;

namespace SocialGames.Domain.Arguments.MyGame
{
    public class MyGameResponse
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public string PlayerName { get; set; }
        public Guid GameId { get; set; }
        public string GameName { get; set; }
        public string StatusGame { get; set; }
        public Guid PlatformId { get; set; }
        public string PlatformName { get; set; }

        public static explicit operator MyGameResponse(Entities.MyGame entity)
        {
            return new MyGameResponse()
            {
                Id = entity.Id,
                Date = entity.Date.ToString(),
                PlayerName = entity.Player.Name.ToString(),
                GameName = entity.Game.Name,
                GameId = entity.GameId,
                StatusGame = entity.MyGameStatus.ToString(),
                PlatformId = entity.Game.PlatFormId,
                PlatformName = entity.Game.PlatForm.Name.ToString(),

            };
        }
    }
}
