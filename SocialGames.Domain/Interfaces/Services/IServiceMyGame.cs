using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.MyGame;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceMyGame
    {
        CreateMyGameResponse Create(CreateMyGameRequest request);
        UpdateMyGameResponse Update(UpdateMyGameRequest request);
        IEnumerable<MyGameResponse> ListMyGame();
        ResponseBase Delete(Guid id);
    }
}
