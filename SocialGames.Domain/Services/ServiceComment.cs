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
        private readonly IServiceGame _serviceGame;
        private readonly IServicePlayer _servicePlayer;
        private readonly IServicePlatForm _servicePlatForm;

        public ServiceComment(IRepositoryComment repositoryComment, IServiceGame serviceGame, IServicePlayer servicePlayer, IServicePlatForm servicePlatForm)
        {
            _repositoryComment = repositoryComment;
            _serviceGame = serviceGame;
            _servicePlayer = servicePlayer;
            _servicePlatForm = servicePlatForm;
        }

        public CommentResponse Create(CreateCommentRequest request)
        {
            _serviceGame.GetById(request.GameId);
            _servicePlayer.GetById(request.PlayerId);
            var comment = new Comment(request.Description,request.GameId,request.PlayerId);
            comment = _repositoryComment.Create(comment);
            var result = GetByMyGame(comment.Id);
            return result;
        }

        public IEnumerable<CommentResponse> GetAll()
        {
            var listComments = _repositoryComment.List(x => x.Game,y => y.Player).ToList();
            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in listComments)
            {
                var result = GetByMyGame(comment.Id);
                listCommentResponses.Add(result); 
            }
            return listCommentResponses;
        }
        public CommentResponse GetById(Guid id)
        {
            return GetByMyGame(id);
        }
        public IEnumerable<CommentResponse> GetByGameId(Guid gameId)
        {
            var game = _serviceGame.GetById(gameId);
            
            var comments = _repositoryComment.List(x => x.Game).Where(x => x.Game.Id == gameId).ToList();

            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in comments)
            {
                var result = GetByMyGame(comment.Id);
                listCommentResponses.Add(result);
            }
            return listCommentResponses;
        }

        public IEnumerable<CommentResponse> GetByPlayerId(Guid playerId)
        {
            var player = _servicePlayer.GetById(playerId);

            var comments = _repositoryComment.List(x => x.Player).Where(x => x.Player.Id == playerId).ToList();

            List<CommentResponse> listCommentResponses = new List<CommentResponse>();
            foreach (var comment in comments)
            {
                var result = GetByMyGame(comment.Id);
                listCommentResponses.Add(result);
            }
            return listCommentResponses;
        }

        public CommentResponse Update(Guid id, UpdateCommentRequest request)
        {
            var comment = ExistComment(id);
            comment.Update(request.Description);
            _repositoryComment.Update(comment);
            return GetByMyGame(comment.Id);
        }
        public void Delete(Guid id)
        {
            var comment = ExistComment(id);
            _repositoryComment.Delete(comment);
        }

        private Comment ExistComment(Guid id)
        {
            var comment = _repositoryComment.List(x => x.Game, y => y.Player).Where(x => x.Id == id).FirstOrDefault();
            if (comment == null) throw new ValidationException("Id Comment not found!");
            return comment;
        }

        private CommentResponse GetByMyGame(Guid commentId)
        {
            var comment = ExistComment(commentId);

            var plarfotm = _servicePlatForm.GetById(comment.Game.PlatFormId);

            var commentReponse = new CommentResponse()
            {
                Id = commentId,
                DateTime = comment.DateTime.ToString(),
                Description = comment.Description,
                PlayerId = comment.PlayerId,
                Player = comment.Player.Name.ToString(),
                GameId = comment.GameId,
                Game = comment.Game.Name,
                PlatformId = comment.Game.PlatFormId,
                Platform = plarfotm.Name,
            };
            return commentReponse;
        }
    }
}
