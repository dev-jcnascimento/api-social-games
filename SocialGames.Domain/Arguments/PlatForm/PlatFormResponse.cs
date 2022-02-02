using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class PlatFormResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator PlatFormResponse(Entities.PlatForm entity)
        {
            return new PlatFormResponse()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
