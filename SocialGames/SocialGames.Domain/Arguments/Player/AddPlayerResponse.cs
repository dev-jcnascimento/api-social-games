using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.Player
{
    internal class AddPlayerResponse : IResponse
    {
        public Guid Id { get; private set; }
        public string Message { get; private set; }
    }
}
