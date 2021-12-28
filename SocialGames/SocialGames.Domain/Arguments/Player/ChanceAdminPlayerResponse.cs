using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class ChanceAdminPlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        public static explicit operator ChanceAdminPlayerResponse(Entities.Player entity)
        {
            return new ChanceAdminPlayerResponse()
            {
                Id = entity.Id,
                Status = entity.Status.ToString()
            };
        }
    }
}
