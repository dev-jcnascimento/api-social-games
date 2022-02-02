using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;

namespace SocialGames.Infra.Persistence.Repositories
{
    public class RepositoryGamePlatForm : RepositoryBase<GamePlatForm,Guid>, IRepositoryGamePlatForm
    {
        protected readonly SocialGamesContext _context;
        public RepositoryGamePlatForm(SocialGamesContext context) : base(context)
        {
            _context = context;
        }
    }
}
