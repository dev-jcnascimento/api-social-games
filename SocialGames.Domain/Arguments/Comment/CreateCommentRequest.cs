using System;

namespace SocialGames.Domain.Arguments.Comment
{
    public class CreateCommentRequest
    {
        public Guid MyGame { get; set; }
        public string Description { get; set; }
    }
}
