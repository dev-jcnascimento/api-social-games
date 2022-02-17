using SocialGames.Domain.Arguments.Player;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServicePlayer
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request);
        PlayerResponse Create(CreatePlayerRequest request);
        IEnumerable<PlayerResponse> GetAll();
        PlayerResponse GetById(Guid id);
        PlayerResponse UpdateAdmin(Guid id, UpdateAdminPlayerRequest request);
        PlayerResponse Update(Guid id,UpdatePlayerRequest request);
        void Delete(Guid id);

    }
}
