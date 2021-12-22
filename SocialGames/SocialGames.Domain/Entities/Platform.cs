using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Entities
{
    internal class Platform : EntityBase
    {
        public Name Name { get; private set; }
        public Platform(Name name)
        {
            Name = name;
        }
    }
}
