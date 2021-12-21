using SocialGames.Domain.Arguments.Player;

namespace SocialGames.Domain.Interfaces.Services
{
    internal interface IServicePlayer
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request);
        AddPlayerResponse Add(AddPlayerRequest request);
    }
}
