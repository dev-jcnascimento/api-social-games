using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class ChancePlatFormResponse : ResponseBase , IResponse
    {
        public string Name { get; set; }

        public static explicit operator ChancePlatFormResponse(Entities.PlatForm entity)
        {
            return new ChancePlatFormResponse()
            {
                Name = entity.Name
            };
        }
    }
}
