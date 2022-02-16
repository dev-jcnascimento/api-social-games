using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.MyGame;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceMyGame
    {
        MyGameResponse Create(CreateMyGameRequest request);
        MyGameResponse Update(UpdateMyGameRequest request);
        IEnumerable<MyGameResponse> ListMyGame();
        ResponseBase Delete(Guid id);
    }
}
