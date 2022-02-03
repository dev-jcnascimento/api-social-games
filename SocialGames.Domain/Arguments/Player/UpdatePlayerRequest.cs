using SocialGames.Domain.Interfaces.Arguments;
using SocialGames.Domain.ValueObject;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class UpdatePlayerRequest : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName{ get;  set; }
        public string LastName { get; set; }
        public string Email { get;  set; }
        public string Status { get; set; }
    }
}
