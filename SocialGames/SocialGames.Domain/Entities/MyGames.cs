using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    internal class MyGames : EntityBase
    {
        public DateTime Date { get; private set; }
        public string Seeing { get; private set; }
        public string Change { get; private set; }
        public string Wish { get; private set; }
    }
}
