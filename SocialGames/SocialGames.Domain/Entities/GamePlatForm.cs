using SocialGames.Domain.Entities.Base;
using System;

namespace SocialGames.Domain.Entities
{
    public class GamePlatForm : EntityBase
    {
        public DateTime Date { get; private set; }
        public Game Game { get; private set; }
        public PlatForm Platform { get; private set; }
        public GamePlatForm(DateTime date, Game game, PlatForm platform)
        {
            Date = date;
            Game = game;
            Platform = platform;
        }

    }
}
