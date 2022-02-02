using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class CreatePlatFormRequest : IRequest
    {
        public string Name { get; set; }
    }
}
