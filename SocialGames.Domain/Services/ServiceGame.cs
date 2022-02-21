using SocialGames.Domain.Arguments.Game;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServiceGame : IServiceGame
    {
        private readonly IRepositoryGame _repositoryGame;
        private readonly IRepositoryMyGame _repositoryMyGame;
        private readonly IRepositoryComment _repositoryComment;
        private readonly IServicePlatForm _servicePlatForm;

        public ServiceGame(IRepositoryGame repositoryGame, IRepositoryMyGame repositoryMyGame, IRepositoryComment repositoryComment, IServicePlatForm servicePlatForm)
        {
            _repositoryGame = repositoryGame;
            _repositoryMyGame = repositoryMyGame;
            _repositoryComment = repositoryComment;
            _servicePlatForm = servicePlatForm;
        }

        public GameResponse Create(CreateGameRequest request)
        {
            _servicePlatForm.GetById(request.PlatFormId);

            if (_repositoryGame.Exists(x => x.Name.ToString().ToLower() == request.Name.ToString().ToLower()
            && x.PlatFormId == request.PlatFormId))
            {
                throw new ValidationException("This Game already exists in Platform!");
            }

            var game = new Game(request.Name, request.Description, request.Producer, request.Gender, request.Distributor, request.PlatFormId);

            var result = _repositoryGame.Create(game);
            result = _repositoryGame.List(x => x.PlatForm).Where(x => x.Id == result.Id).FirstOrDefault();
            return (GameResponse)result;
        }
        public IEnumerable<GameResponse> GetAll()
        {
            return _repositoryGame.List(x => x.PlatForm).ToList().Select(x => (GameResponse)x).ToList();
        }
        public GameResponse GetById(Guid id)
        {
            var result = ExistGame(id);
            result = _repositoryGame.List(x => x.PlatForm).Where(x => x.Id == result.Id).FirstOrDefault();

            return (GameResponse)result;
        }
        public IEnumerable<GameResponse> GetByPlatformId(Guid platformId)
        {
            _servicePlatForm.GetById(platformId);
            var result = _repositoryGame.List(x => x.PlatForm).Where(x => x.PlatFormId == platformId).ToList();

            return result.Select(x => (GameResponse)x).ToList();
        }

        public GameResponse Update(Guid id, UpdateGameRequest request)
        {
            var game = ExistGame(id);
            game.UpdateGame(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
            var result = _repositoryGame.Update(game);
            result = _repositoryGame.List(x => x.PlatForm).Where(x => x.Id == result.Id).FirstOrDefault();

            return (GameResponse)result;
        }

        public void Delete(Guid id)
        {
            var game = ExistGame(id);
            var myGame = _repositoryMyGame.List(x => x.Game).Any(x => x.GameId == id);
            if (myGame == true) throw new ValidationException("This Game Id is linked to MyGame!");
            var comment = _repositoryComment.List(x => x.Game).Any(x => x.GameId == id);
            if (comment == true) throw new ValidationException("This Game Id is linked to Comment!");
            _repositoryGame.Delete(game);
        }

        private Game ExistGame(Guid id)
        {
            var game = _repositoryGame.GetById(id);
            if (game == null) throw new ValidationException("Id Game not found!");
            return game;
        }
    }
}
