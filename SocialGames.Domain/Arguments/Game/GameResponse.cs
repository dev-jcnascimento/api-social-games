using System;

namespace SocialGames.Domain.Arguments.Game
{
    public class GameResponse
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Producer { get; set; }
        public string Gender { get; set; }
        public string Distributor { get; set; }

        public static explicit operator GameResponse(Entities.Game entity)
        {
            return new GameResponse()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Producer = entity.Producer,
                Gender = entity.Gender,
                Distributor = entity.Distributor,
            };
        }
    }
}
