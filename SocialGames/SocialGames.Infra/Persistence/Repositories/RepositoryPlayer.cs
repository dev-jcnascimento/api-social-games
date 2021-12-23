using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
