using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Entities
{
    public class PlatForm : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<Game> Games { get; private set; }
        protected PlatForm()
        {
        }
        public PlatForm(string name)
        {
            Validate(name);
        }
        public void ChancePlatForm(string name)
        {
            Validate(name);
        }
        private void Validate(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 50)
            {
                throw new Exception("Name cannot be empty and cannot be shorter than 30 characters.");
            }
            Name = name;
        }
    }
}
