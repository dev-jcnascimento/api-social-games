using SocialGames.Domain.Arguments.Base;
using System;

namespace SocialGames.Domain.Arguments.Game
{
    public class ChanceGameResponse : ResponseBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Gender { get; set; }
        public string Distributor { get; set; }

        public static explicit operator ChanceGameResponse(Entities.Game entity)
        {
            return new ChanceGameResponse()
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
