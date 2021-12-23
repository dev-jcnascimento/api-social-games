using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Arguments.Player
{
    public class AddPlayerRequest : IRequest
    {
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
    }
}
