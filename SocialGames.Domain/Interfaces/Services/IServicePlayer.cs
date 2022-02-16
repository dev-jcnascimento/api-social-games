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
        IEnumerable<PlayerResponse> GetAllPlayers();
        PlayerResponse GetById(Guid id);
        UpdateAdminPlayerResponse UpdateAdmin(UpdateAdminPlayerRequest request);
        UpdatePlayerResponse Update(UpdatePlayerRequest request);
        ResponseBase Delete(Guid id);

    }
}
