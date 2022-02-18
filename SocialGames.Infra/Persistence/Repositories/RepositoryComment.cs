using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryComment : RepositoryBase<Comment,Guid>, IRepositoryComment
    {
        private readonly SocialGamesContext _context;

        public RepositoryComment(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
