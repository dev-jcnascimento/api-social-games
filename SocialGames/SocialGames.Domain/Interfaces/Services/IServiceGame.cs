using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Game;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceGame
    {
        AddGameResponse Add(AddGameRequest request);
        ChanceGameResponse Chance(ChanceGameRequest request);
        IEnumerable<GameResponse> List();
        ResponseBase Delete(Guid id);
    }
}
