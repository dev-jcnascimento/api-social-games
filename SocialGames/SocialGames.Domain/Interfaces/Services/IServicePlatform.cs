using SocialGames.Domain.Arguments.PlatForm;

namespace SocialGames.Domain.Interfaces.Services
{
    internal interface IServicePlatform
    {
        AddPlatFormResponse Add(AddPlatFormRequest request);
    }
}
