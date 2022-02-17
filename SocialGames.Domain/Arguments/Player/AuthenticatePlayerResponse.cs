using SocialGames.Domain.Arguments.Base;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class AuthenticatePlayerResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public static explicit operator AuthenticatePlayerResponse(Entities.Player entity)
        {
            return new AuthenticatePlayerResponse()
            {

                Email = entity.Email.Address,
                Name = entity.Name.FirstName,
                Status = (int)entity.Status
            };
        }
    }
}

