using SocialGames.Domain.Entities.Base;

namespace SocialGames.Domain.Entities
{
    public class PlatForm : EntityBase
    {
        public string Name { get; private set; }
        public PlatForm(string name)
        {
            Name = name;
        }
        public void ChancePlatForm(string name)
        {
            Name = name;
        }
    }
}
