using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using System;

namespace SocialGames.Domain.Entities
{
    public class MyGame : EntityBase
    {
        public DateTime Date { get; private set; }
        public MyGameStatus MyGameStatus { get; private set; }
        public MyGame(DateTime date, MyGameStatus myGameStatus)
        {
            Date = date;
            MyGameStatus = MyGameStatus.NewGame;
        }
    }
}
