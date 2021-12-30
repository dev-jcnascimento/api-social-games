using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class AddPlatFormResponse : ResponseBase, IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static explicit operator AddPlatFormResponse(Entities.PlatForm entity)
        {
            return new AddPlatFormResponse()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }

}
