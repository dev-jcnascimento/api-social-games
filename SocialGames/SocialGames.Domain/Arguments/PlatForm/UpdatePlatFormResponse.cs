using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class UpdatePlatFormResponse : ResponseBase , IResponse
    {
        public string Name { get; set; }

        public static explicit operator UpdatePlatFormResponse(Entities.PlatForm entity)
        {
            return new UpdatePlatFormResponse()
            {
                Name = entity.Name
            };
        }
    }
}
