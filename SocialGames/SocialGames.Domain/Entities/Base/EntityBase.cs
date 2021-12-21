namespace SocialGames.Domain.Entities.Base
{
    internal abstract class EntityBase
    {
        public Guid Id { get; private set; }
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
