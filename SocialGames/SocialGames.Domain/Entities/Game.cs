using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    internal class Game : EntityBase
    {
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Producer { get;  set; }
        public string Gender { get;  set; }
        public string Distributor { get;  set; }
    }
}
