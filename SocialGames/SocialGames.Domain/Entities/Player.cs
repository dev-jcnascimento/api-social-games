using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Entities
{
    internal class Player : EntityBase
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Status Status { get; private set; }

        public Player(Email email, Password password)
        {
            Email = email;
            Password = password;
        }

        public Player(Name name, Email email, Password password, Status status)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = status;
        }

      

    }
}
