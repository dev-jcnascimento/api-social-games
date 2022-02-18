using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class PlayerResponse
    {
        public Guid Id { get; set; }
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string Status { get;  set; }

        public static explicit operator PlayerResponse(Entities.Player entity)
        {
            return new PlayerResponse()
            {
                Id = entity.Id,
                FirstName = entity.Name.FirstName,
                LastName = entity.Name.LastName,
                Email = entity.Email.Address,
                Status = entity.Status.ToString(),
            };
        }
    }
}
