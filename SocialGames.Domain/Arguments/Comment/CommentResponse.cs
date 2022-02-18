using System;

namespace SocialGames.Domain.Arguments.Comment
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public Guid PlayerId { get; set; }
        public string Player { get; set; }
        public Guid GameId { get; set; }
        public string Game { get; set; }
        public Guid PlatformId { get; set; }
        public string Platform { get; set; }

    }
}
