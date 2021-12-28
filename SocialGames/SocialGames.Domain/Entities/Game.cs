using SocialGames.Domain.Entities.Base;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Entities
{
    public class Game : EntityBase
    {
        public Name Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Gender { get; private set; }
        public string Distributor { get; private set; }
        public Game(Name name, string description, string producer, string gender, string distributor)
        {
            Name = name;
            Description = description;
            Producer = producer;
            Gender = gender;
            Distributor = distributor;
        }

    }
}
