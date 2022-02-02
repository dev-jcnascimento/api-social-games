using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.PlatForm
{
    public class UpdatePlatFormRequest : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
