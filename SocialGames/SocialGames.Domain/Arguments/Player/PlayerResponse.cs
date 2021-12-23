using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Arguments.Player
{
    public class PlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public int Status { get;  set; }

        public static explicit operator PlayerResponse(Entities.Player entity)
        {
            return new PlayerResponse()
            {
                Id = entity.Id,
                Name = entity.Name.ToString(),
                FirstName = entity.Name.FirstName,
                LastName = entity.Name.LastName,
                Email = entity.Email.Address,
                Status = (int)entity.Status,
            };
        }
    }
}
