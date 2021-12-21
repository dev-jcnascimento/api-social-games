using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    internal class PlatformGames : EntityBase
    {
        public DateTime Date { get;  set; }
        public Game Game { get;  set; }
        public Platform Platform { get;  set; }
    }
}
