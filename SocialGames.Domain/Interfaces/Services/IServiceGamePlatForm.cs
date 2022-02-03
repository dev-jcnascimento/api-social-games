using SocialGames.Domain.Arguments.GamePlatForm;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceGamePlatForm
    {
        CreateGamePlatFormResponse Create(CreateGamePlatFormRequest request);
        UpdateGamePlatFormResponse Update(UpdateGamePlatFormRequest request);
        IEnumerable<GamePlatFormResponse> GetAll();
        GamePlatFormResponse Delete(Guid Id);
    }
}
