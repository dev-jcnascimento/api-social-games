using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.MyGame;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceMyGame
    {
        MyGameResponse Create(CreateMyGameRequest request);
        IEnumerable<MyGameResponse> GetAll();
        MyGameResponse GetById(Guid id);
        MyGameResponse Update(Guid id,UpdateMyGameRequest request);
        void Delete(Guid id);
    }
}
