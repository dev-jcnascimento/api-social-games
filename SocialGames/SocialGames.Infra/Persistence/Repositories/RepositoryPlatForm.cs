using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryPlatForm : RepositoryBase<PlatForm, Guid>, IRepositoryPlatForm
    {
        protected readonly SocialGamesContext _context;
        public RepositoryPlatForm(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
