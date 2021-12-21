using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories.Base;

namespace SocialGames.Domain.Interfaces.Repositories
{
    internal interface IRepositoryPlayer : IRepositoryBase<Player,Guid>
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request);
        Guid Add(Player player);
    }
}
