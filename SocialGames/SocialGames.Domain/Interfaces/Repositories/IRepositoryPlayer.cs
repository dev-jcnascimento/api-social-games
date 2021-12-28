using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories.Base;
using System;

namespace SocialGames.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer : IRepositoryBase<Player,Guid>
    {
    }
}
