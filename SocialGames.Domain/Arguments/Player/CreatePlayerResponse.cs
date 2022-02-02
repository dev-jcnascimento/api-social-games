using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class CreatePlayerResponse : ResponseBase,IResponse
    {
        public Guid Id { get; set; }

        public static explicit operator CreatePlayerResponse(Entities.Player entity)
        {
            return new CreatePlayerResponse()
            {
                Id = entity.Id,
            };
        }
    }
}
