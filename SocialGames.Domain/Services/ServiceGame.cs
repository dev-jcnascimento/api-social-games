using SocialGames.Domain.Arguments.Base;
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

        public ServiceGame(IRepositoryGame repositoryGame)
        {
            _RepositoryGame = repositoryGame;
        }

        public GameResponse Create(CreateGameRequest request)
        {
            Game game = new Game(request.Name, request.Description, request.Producer, request.Gender, request.Distributor, request.PlatFormId);
            if (_RepositoryGame.Exists(x => x.Name.ToString().ToLower() == request.Name.ToString().ToLower()))
            {
                throw new ValidationException("This Game already exists!");
            }
            var response = _RepositoryGame.Create(game);
            return (GameResponse)game;
        }
        public IEnumerable<GameResponse> GetAll()
        {
            return _RepositoryGame.List().ToList().Select(x => (GameResponse)x).ToList();
        }
        public GameResponse GetById(Guid id)
        {
            var game = ExistGame(id);
            return (GameResponse)game;
        }

        public GameResponse Update(Guid id, UpdateGameRequest request)
        {
            var game = ExistGame(id);
            game.UpdateGame(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
            var response = _RepositoryGame.Update(game);
            return (GameResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            var game = ExistGame(id);
            _RepositoryGame.Delete(game);
            return (ResponseBase)game;
        }

        private Game ExistGame(Guid id)
        {
            var game = _RepositoryGame.GetById(id);
            if (game == null) throw new ValidationException("Id Game not found!");
            return game;
        }
    }
}
