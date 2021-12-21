using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.PlatForm
{
    internal class AddPlatFormRequest : IRequest
    {
        public string Name { get; set; }
    }
}
