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
        private readonly IRepositoryGame _RepositoryGame;
        private readonly IServicePlatForm _ServicePlatForm;

        public ServiceGame(IRepositoryGame repositoryGame, IServicePlatForm servicePlatForm)
        {
            _RepositoryGame = repositoryGame;
            _ServicePlatForm = servicePlatForm;
        }

        public GameResponse Create(CreateGameRequest request)
        {
            _ServicePlatForm.GetById(request.PlatFormId);

            if (_RepositoryGame.Exists(x => x.Name.ToString().ToLower() == request.Name.ToString().ToLower()
            && x.PlatFormId == request.PlatFormId))
            {
                throw new ValidationException("This Game already exists in Platform!");
            }

            var game = new Game(request.Name, request.Description, request.Producer, request.Gender, request.Distributor, request.PlatFormId);

            var result = _RepositoryGame.Create(game);
            var test = _RepositoryGame.List(x => x.PlatForm).Where(x => x.Id == result.Id).FirstOrDefault();
            return (GameResponse)result;
        }
        public IEnumerable<GameResponse> GetAll()
        {
            return _RepositoryGame.List(x => x.PlatForm).ToList().Select(x => (GameResponse)x).ToList();
        }
        public GameResponse GetById(Guid id)
        {
            var game = ExistGame(id);
            var result = _RepositoryGame.List(x => x.PlatForm).Single(x => x.Id == game.Id);

            return (GameResponse)result;
        }

        public GameResponse Update(Guid id, UpdateGameRequest request)
        {
            var game = ExistGame(id);
            game.UpdateGame(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
            var result = _RepositoryGame.Update(game);
            return (GameResponse)result;
        }

        public void Delete(Guid id)
        {
            var game = ExistGame(id);
            _RepositoryGame.Delete(game);
        }

        private Game ExistGame(Guid id)
        {
            var game = _RepositoryGame.GetById(id);
            if (game == null) throw new ValidationException("Id Game not found!");
            return game;
        }
    }
}
