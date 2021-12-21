using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Arguments.Player
{
    internal class AuthenticatePlayerRequest : IRequest
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
