using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryGame : RepositoryBase<Game,Guid>, IRepositoryGame
    {
        protected readonly SocialGamesContext _context;
        public RepositoryGame(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
