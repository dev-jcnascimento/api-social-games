using SocialGames.Domain.Extension;

namespace SocialGames.Domain.ValueObject
{
    internal class Email
    {
        public string Address { get; private set; }
        public Email(string address)
        {
            Address = address;
            Address = Address.ValidarEmail();
        } 
    }
}
