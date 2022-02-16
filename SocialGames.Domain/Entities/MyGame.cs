using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using System;

namespace SocialGames.Domain.Entities
{
    public class MyGame : EntityBase
    {
        public DateTime Date { get; private set; }
        public MyGameStatus MyGameStatus { get; private set; }
        public Guid PlayerId { get; private set; }
        public Player Player { get; private set; }
        public Guid GameId { get; private set; }
        public Game Game { get; private set; }
        public MyGame(Guid playerId, Guid gameId)
        {
            Date = DateTime.Now;
            MyGameStatus = MyGameStatus.NewGame;
            PlayerId = playerId;
            GameId = gameId;
        }
        public void Update(MyGameStatus myGameStatus, Guid gameId)
        {
            MyGameStatus = myGameStatus;
            GameId = gameId;
        }
    }
}
