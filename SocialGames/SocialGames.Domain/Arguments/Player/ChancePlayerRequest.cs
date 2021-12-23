using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Arguments.Player
{
    public class ChancePlayerRequest : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
    }
}
