using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryMyGame : RepositoryBase<MyGame, Guid>, IRepositoryMyGame
    {
        protected readonly SocialGamesContext _context;
        public RepositoryMyGame(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
