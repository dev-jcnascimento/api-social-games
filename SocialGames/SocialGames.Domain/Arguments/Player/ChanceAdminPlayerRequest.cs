using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class ChanceAdminPlayerRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
