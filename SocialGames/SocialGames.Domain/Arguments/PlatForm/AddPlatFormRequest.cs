﻿using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class AddPlatFormRequest : IRequest
    {
        public string Name { get; set; }
    }
}
