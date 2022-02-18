using SocialGames.Domain.Arguments.Comment;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServiceComment : IServiceComment
    {
        private readonly IRepositoryComment _repositoryComment;
        private readonly IRepositoryGame _repositoryGame;
        private readonly IRepositoryPlayer _repositoryPlayer;
        private readonly IServiceMyGame _serviceMyGame;

        public ServiceComment(IRepositoryComment repositoryComment, IRepositoryGame repositoryGame, IRepositoryPlayer repositoryPlayer)
        {
            _repositoryComment = repositoryComment;
            _repositoryGame = repositoryGame;
            _repositoryPlayer = repositoryPlayer;
        }

        public CommentResponse Create(CreateCommentRequest request)
        {
            _serviceMyGame.GetById(request.MyGameId);
            var comment = new Comment(request.Description,request.MyGameId);
            comment = _repositoryComment.Create(comment);
            var result = GetByMyGame(request.MyGameId, comment.Id);
            return result;
        }

        public IEnumerable<CommentResponse> GetAll()
        {
            var listComments = _repositoryComment.List(x => x.MyGame).ToList();
            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in listComments)
            {
                var result = GetByMyGame(comment.MyGameId, comment.Id);
                listCommentResponses.Add(result); 
            }
            return listCommentResponses;
        }
        public CommentResponse GetById(Guid id)
        {
            var comment = ExistComment(id);
            return GetByMyGame(comment.MyGameId, comment.Id);
        }
        public IEnumerable<CommentResponse> GetByGameId(Guid gameId)
        {
            var game = _repositoryGame.GetById(gameId);
            if (game == null) throw new ValidationException("GameId not found!");
            var comments = _repositoryComment.List(x => x.MyGame).Where(x => x.MyGame.GameId == gameId).ToList();

            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in comments)
            {
                var result = GetByMyGame(comment.MyGameId, comment.Id);
                listCommentResponses.Add(result);
            }
            return listCommentResponses;
        }

        public IEnumerable<CommentResponse> GetByPlayerId(Guid playerId)
        {
            var player = _repositoryPlayer.GetById(playerId);
            if (player == null) throw new ValidationException("PlayerId not found!");
            var comments = _repositoryComment.List(x => x.MyGame).Where(x => x.MyGame.PlayerId == playerId).ToList();

            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in comments)
            {
                var result = GetByMyGame(comment.MyGameId, comment.Id);
                listCommentResponses.Add(result);
            }
            return listCommentResponses;
        }

        public CommentResponse Update(Guid id, UpdateCommentRequest request)
        {
            var comment = ExistComment(id);
            comment.Update(request.Description);
            _repositoryComment.Update(comment);
            return GetByMyGame(comment.MyGameId, comment.Id);
        }
        public void Delete(Guid id)
        {
            var comment = ExistComment(id);
            _repositoryComment.Delete(comment);
        }

        private Comment ExistComment(Guid id)
        {
            var comment = _repositoryComment.GetById(id);
            if (comment == null) throw new ValidationException("Id Comment not found!");
            return comment;
        }

        private CommentResponse GetByMyGame(Guid myGameId,Guid commentId)
        {
            var myGame = _serviceMyGame.GetById(myGameId);
            var player = _repositoryPlayer.GetById(myGame.PlayerId);
            var game = _repositoryGame.List(x => x.PlatForm).Where(x => x.Id == myGame.GameId).SingleOrDefault();
            var comment = GetById(commentId);

            var commentReponse = new CommentResponse()
            {
                Id = commentId,
                DateTime = comment.DateTime.ToString(),
                Description = comment.Description,
                PlayerId = player.Id,
                Player = player.Name.ToString(),
                GameId = game.Id,
                Game = game.Name,
                PlatformId = game.PlatForm.Id,
                Platform = game.PlatForm.Name,
            };
            return commentReponse;
        }
    }
}
