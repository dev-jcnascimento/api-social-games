using SocialGames.Domain.Entities.Base;
using System;
using System.Runtime.InteropServices;

namespace SocialGames.Domain.Entities
{
    public class GamePlatForm : EntityBase
    {
        public DateTime Date { get; private set; }
        public Guid GameId { get; set; }
        public Game Game { get; private set; }
        public PlatForm PlatForm { get; private set; }

        protected GamePlatForm()
        {
        }
        public GamePlatForm([Optional]DateTime date, Game game, PlatForm platform)
        {
            Validated(date, game, platform);
        }
        private void Validated(DateTime date, Game game, PlatForm platform)
        {
            if (date == null)
            {
                Date = DateTime.Now;
            }
            Date = date;
            if (game == null)
            {
                throw new Exception("Game is necessary!");
            }
            Game = game;    
            if (platform == null)
            {
                throw new Exception("PlatForm is necessary!");
            }
            PlatForm = platform;
        }
        public override string ToString()
        {
            return "Game: "
                + Game.Name
                + ", PlatForm: "
                + PlatForm.Name;
        }
    }
}
