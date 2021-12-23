using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories.Base;

namespace SocialGames.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer : IRepositoryBase<Player,Guid>
    {
    }
}
