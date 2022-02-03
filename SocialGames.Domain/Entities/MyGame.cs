using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using System;
using System.Runtime.InteropServices;

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
        public MyGame(DateTime? date, MyGameStatus? myGameStatus, Guid playerId, Guid gameId)
        {
            if (date == null)
            {
                Date = DateTime.Now;
            }
            Date = (DateTime)date;
            if (myGameStatus == null)
            {
                MyGameStatus = MyGameStatus.NewGame;
            }
            MyGameStatus = (MyGameStatus)myGameStatus;
            PlayerId = playerId;
            GameId = gameId;
        }
    }
}
