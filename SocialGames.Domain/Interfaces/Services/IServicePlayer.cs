using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Player;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServicePlayer
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request);
        CreatePlayerResponse Create(CreatePlayerRequest request);
        UpdatePlayerResponse Update(UpdatePlayerRequest request);
        UpdateAdminPlayerResponse UpdateAdmin(UpdateAdminPlayerRequest request);
        IEnumerable<PlayerResponse> ListPlayers();
        ResponseBase Delete(Guid id);

    }
}
