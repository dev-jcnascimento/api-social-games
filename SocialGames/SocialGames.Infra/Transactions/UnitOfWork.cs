using SocialGames.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialGamesContext _context;

        public UnitOfWork(SocialGamesContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();  
        }
    }
}
