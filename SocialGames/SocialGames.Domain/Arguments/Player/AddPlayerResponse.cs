using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class AddPlayerResponse : ResponseBase,IResponse
    {
        public Guid Id { get; set; }

        public static explicit operator AddPlayerResponse(Entities.Player entity)
        {
            return new AddPlayerResponse()
            {
                Id = entity.Id,
            };
        }
    }
}
