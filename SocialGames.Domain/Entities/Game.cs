using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SocialGames.Domain.Entities
{
    public class Game : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Gender { get; private set; }
        public string Distributor { get; private set; }
        public Guid PlatFormId { get; private set; }
        public PlatForm PlatForm { get; private set; }
        public ICollection<MyGame> MyGames { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        protected Game()
        {
        }
        public Game(string name)
        {
            Validate(name);
        }
        public Game(string name, string description, string producer, string gender, string distributor,Guid platFormId)
        {
            Validate(name, description, producer, gender, distributor);
            PlatFormId = platFormId;
        }
        public void UpdateGame(string name, string description, string producer, string gender, string distributor)
        {
            Validate(name, description, producer, gender, distributor);
        }
        private void Validate(string name, [Optional] string description, [Optional] string producer, [Optional] string gender, [Optional] string distributor)
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
