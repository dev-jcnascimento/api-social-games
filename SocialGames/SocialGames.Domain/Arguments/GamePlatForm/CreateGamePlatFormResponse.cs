using SocialGames.Domain.Arguments.Base;

namespace SocialGames.Domain.Arguments.GamePlatForm
{
    public class CreateGamePlatFormResponse : ResponseBase
    {
        public string Game { get; set; }
        public string PlatForm { get; set; }
        public string GamePlatForm { get; set; }    

        public static explicit operator CreateGamePlatFormResponse(Entities.GamePlatForm entity)
        {
            return new CreateGamePlatFormResponse()
            {
                Game = entity.Game.Name.ToString(),
                PlatForm = entity.PlatForm.Name.ToString(),
                GamePlatForm = entity.ToString()
            };
        }
    }
}
