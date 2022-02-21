using System;

namespace SocialGames.Domain.Arguments.Comment
{
    public class CreateCommentRequest
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public string Description { get; set; }
    }
}
