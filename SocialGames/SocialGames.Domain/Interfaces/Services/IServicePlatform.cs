using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.PlatForm;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServicePlatForm
    {
        AddPlatFormResponse Add(AddPlatFormRequest request);
        ChancePlatFormResponse Chance(ChancePlatFormRequest request);
        IEnumerable<PlatFormResponse> ListPlayers();
        ResponseBase DeletePlayer(Guid id);
    }
}
