using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class CreatePlatFormResponse : ResponseBase, IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CreatePlatFormResponse(Entities.PlatForm entity)
        {
            return new CreatePlatFormResponse()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }

}
