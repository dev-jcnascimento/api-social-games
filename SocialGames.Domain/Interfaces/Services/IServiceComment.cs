using SocialGames.Domain.Arguments.Comment;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServiceComment
    {
        CommentResponse Create(CreateCommentRequest request);
        IEnumerable<CommentResponse> GetAll();
        CommentResponse GetById(Guid id);
        IEnumerable<CommentResponse> GetByPlayerId(Guid playerId);
        IEnumerable<CommentResponse> GetByGameId(Guid gameId);
        CommentResponse Update(Guid id, UpdateCommentRequest request);
        void Delete(Guid id);
    }
}
