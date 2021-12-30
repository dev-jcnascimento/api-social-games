using SocialGames.Domain.Arguments.Base;
using System;

namespace SocialGames.Domain.Arguments.Game
{
    public class AddGameResponse : ResponseBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Gender { get; set; }
        public string Distributor { get; set; }

        public static explicit operator AddGameResponse(Entities.Game entity)
        {
            return new AddGameResponse()
            {
                Name = entity.Name,
                Description = entity.Description,
                Producer = entity.Producer,
                Gender = entity.Gender,
                Distributor = entity.Distributor
            };
        }
    }
}
