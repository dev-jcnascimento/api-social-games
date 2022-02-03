using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Game;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Domain.ValueObject;
using System;
using System.Collections.Generic;
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

        public CreateGameResponse Create(CreateGameRequest request)
        {
            if (request != null)
            {
                Game game = new Game(request.Name, request.Description, request.Producer, request.Gender, request.Distributor,request.PlatFormId);
                if (_RepositoryGame.Exists(x => x.Name.ToString().ToLower() == request.Name.ToString().ToLower()))
                {
                    throw new Exception("This Game already exists!");
                }
                var response = _RepositoryGame.Create(game);
                return (CreateGameResponse)game;
            }
            else
            {
                throw new Exception("Request is required!");
            }
        }

        public UpdateGameResponse Update(UpdateGameRequest request)
        {
            if (request == null)
            {
                throw new Exception("Request is required!");
            }
            Game game = _RepositoryGame.GetById(request.Id);
            if(game == null)
            {
                throw new Exception("Not found Game!");
            }
            game.UpdateGame(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
                var response = _RepositoryGame.Update(game);
                return (UpdateGameResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            Game game = _RepositoryGame.GetById(id);
            if(game == null)
            {
                throw new Exception("Id Game not Found!");
            }
            _RepositoryGame.Delete(game);
            return (ResponseBase)game;
        }

        public IEnumerable<GameResponse> List()
        {
            return _RepositoryGame.List().ToList().Select(x => (GameResponse)x).ToList();
        }
    }
}
