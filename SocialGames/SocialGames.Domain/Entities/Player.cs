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
        public Status Status { get; private set; }
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
            Status = Status.Em_Anlise;
        }
        public void ChancePlayerAdmin(Status status)
        {
            Status = Status.Ativo;
        }
        public void ChancePlayer(Name name, Email email, Status status)
        {
            if (status != Status.Ativo)
            {
                throw new Exception("O jogador deve ser ativo para ser Alterado!");
            }
            Name = name;
            Email = email;
        }
        public override string ToString()
        {
            return Name.FirstName + " " + Name.LastName;
        }
    }
}
