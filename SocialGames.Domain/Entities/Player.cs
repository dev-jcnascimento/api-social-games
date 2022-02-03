using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;
using System;

namespace SocialGames.Domain.Entities
{
    public class Player : EntityBase
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public PlayerStatus Status { get; private set; }
        protected Player()
        {
        }
        public Player(Email email, Password password)
        {
            Email = email;
            Password = password;
        }
        public Player(Name name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
            Status = PlayerStatus.In_Analysis;
        }
        public void UpdatePlayerAdmin(PlayerStatus status)
        {
            Status = PlayerStatus.Active;
        }
        public void UpdatePlayer(Name name, Email email, PlayerStatus status)
        {
            if (status != PlayerStatus.Active)
            {
                throw new Exception("Player must be active to be Changed!");
            }
            Name = name;
            Email = email;
        }
    }
}
