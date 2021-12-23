﻿using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Player;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServicePlayer
    {
        AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request);
        AddPlayerResponse Add(AddPlayerRequest request);
        ChancePlayerResponse Chance(ChancePlayerRequest request);
        IEnumerable<PlayerResponse> ListPlayers();
        ResponseBase DeletePlayer(Guid id);

    }
}
