using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    internal class PlatformGames : EntityBase
    {
        public DateTime Date { get; private set; }
        public Game Game { get; private set; }
        public Platform Platform { get; private set; }
    }
}
