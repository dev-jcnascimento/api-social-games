using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    internal class MyGames : EntityBase
    {
        public DateTime Date { get;  set; }
        public string Seeing { get;  set; }
        public string Change { get;  set; }
        public string Wish { get;  set; }
    }
}
