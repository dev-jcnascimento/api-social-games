namespace SocialGames.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
