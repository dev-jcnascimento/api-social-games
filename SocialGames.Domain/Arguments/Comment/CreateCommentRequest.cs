using System;

namespace SocialGames.Domain.Arguments.Comment
{
    public class CreateCommentRequest
    {
        public Guid MyGameId { get; set; }
        public string Description { get; set; }
    }
}
