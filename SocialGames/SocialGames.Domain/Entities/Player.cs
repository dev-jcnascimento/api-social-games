using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Entities
{
    internal class Player : EntityBase
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public Status Status { get; private set; }
    }
}
