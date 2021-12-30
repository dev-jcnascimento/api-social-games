using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories.Base;
using System;

namespace SocialGames.Domain.Interfaces.Repositories
{
    public interface IRepositoryGame : RepositoryBase<Game,Guid>
    {
    }
}
