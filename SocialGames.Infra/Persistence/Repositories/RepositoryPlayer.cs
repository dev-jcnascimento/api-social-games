using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryPlayer : RepositoryBase<Player,Guid>, IRepositoryPlayer
    {
        protected readonly SocialGamesContext _context;
        public RepositoryPlayer(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
