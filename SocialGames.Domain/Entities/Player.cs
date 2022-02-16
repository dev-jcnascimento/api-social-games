using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SocialGames.Domain.Entities
{
    public class Player : EntityBase
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public PlayerStatus Status { get; private set; }
        public ICollection<PlatForm> PlatForms { get; private set; }
        public ICollection<Game> Games { get; private set; }
        protected Player()
        {
        }
        public Player(Name name, Email email, Password password, [Optional] PlayerStatus playerStatus)
        {
            Name = name;
            Email = email;
            Password = password;
            if (string.IsNullOrEmpty(playerStatus.ToString()))
            {
                Status = PlayerStatus.In_Analysis;
            }
            Status = playerStatus;
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
