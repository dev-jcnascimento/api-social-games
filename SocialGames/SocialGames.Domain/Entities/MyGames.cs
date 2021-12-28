using SocialGames.Domain.Entities.Base;
using System;

namespace SocialGames.Domain.Entities
{
    internal class MyGames : EntityBase
    {
        public DateTime Date { get; private set; }
        public string Seeing { get; private set; }
        public string Change { get; private set; }
        public string Wish { get; private set; }
        public MyGames(DateTime date, string seeing, string change, string wish)
        {
            Date = date;
            Seeing = seeing;
            Change = change;
            Wish = wish;
        }
    }
}
