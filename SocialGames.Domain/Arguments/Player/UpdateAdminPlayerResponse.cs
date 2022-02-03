using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class UpdateAdminPlayerResponse : ResponseBase, IResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }

        public static explicit operator UpdateAdminPlayerResponse(Entities.Player entity)
        {
            return new UpdateAdminPlayerResponse()
            {
                Id = entity.Id,
                Status = entity.Status.ToString()
            };
        }
    }
}
