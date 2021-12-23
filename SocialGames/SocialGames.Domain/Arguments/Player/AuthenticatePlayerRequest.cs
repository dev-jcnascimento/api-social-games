﻿using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Arguments.Player
{
    public class AuthenticatePlayerRequest : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
