using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class UpdateAdminPlayerRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
