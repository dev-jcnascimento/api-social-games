using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class ChancePlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public static explicit operator ChancePlayerResponse(Entities.Player entity)
        {
            return new ChancePlayerResponse()
            {
                Id = entity.Id,
                FirstName = entity.Name.FirstName,
                Email = entity.Email.Address,
                Status = entity.Status.ToString()
            };
        }
    }
}
