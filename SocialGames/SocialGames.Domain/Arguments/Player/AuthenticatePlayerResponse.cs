using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.Player
{
    internal class AuthenticatePlayerResponse : IResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
