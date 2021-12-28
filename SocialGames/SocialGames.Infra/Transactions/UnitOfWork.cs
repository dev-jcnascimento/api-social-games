using SocialGames.Infra.Persistence;

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
