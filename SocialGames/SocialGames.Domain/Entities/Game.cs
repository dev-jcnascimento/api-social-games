using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.ValueObject;
using System;

namespace SocialGames.Domain.Entities
{
    public class Game : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Gender { get; private set; }
        public string Distributor { get; private set; }
        protected Game()
        {
        }
        public Game(string name, string description, string producer, string gender, string distributor)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 30)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            Name = name;

            if (string.IsNullOrEmpty(description))
            {
                description = "Not Description!";
            }
            Description = description;
            if (string.IsNullOrEmpty(producer))
            {
                producer = "Not Producer";
            }
            Producer = producer;
            if (string.IsNullOrEmpty(gender))
            {
                gender = "Not Gender";
            }
            Gender = gender;
            if (string.IsNullOrEmpty(distributor))
            {
                distributor = "Not Distributor";
            }
            Distributor = distributor;
        }
        public void EditGame(string name, string description, string producer, string gender, string distributor)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 30)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            Name = name;

            if (string.IsNullOrEmpty(description))
            {
                description = "Not Description!";
            }
            Description = description;
            if (string.IsNullOrEmpty(producer))
            {
                producer = "Not Producer";
            }
            Producer = producer;
            if (string.IsNullOrEmpty(gender))
            {
                gender = "Not Gender";
            }
            Gender = gender;
            if (string.IsNullOrEmpty(distributor))
            {
                distributor = "Not Distributor";
            }
            Distributor = distributor;
        }

    }
}
