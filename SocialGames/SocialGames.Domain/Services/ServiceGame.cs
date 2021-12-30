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

        public AddGameResponse Add(AddGameRequest request)
        {
            if (request != null)
            {
                Game game = new Game(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
                if (_RepositoryGame.Exists(x => x.Name.ToString().ToLower() == request.Name.ToString().ToLower()))
                {
                    throw new Exception("This Game already exists!");
                }
                var response = _RepositoryGame.Add(game);
                return (AddGameResponse)game;
            }
            else
            {
                throw new Exception("Request is required!");
            }
        }

        public ChanceGameResponse Chance(ChanceGameRequest request)
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
            game.EditGame(request.Name, request.Description, request.Producer, request.Gender, request.Distributor);
                var response = _RepositoryGame.Edit(game);
                return (ChanceGameResponse)response;
        }

        public ResponseBase Delete(Guid id)
        {
            Game game = _RepositoryGame.GetById(id);
            if(game == null)
            {
                throw new Exception("Id Game not Found!");
            }
            _RepositoryGame.Remove(game);
            return (ResponseBase)game;
        }

        public IEnumerable<GameResponse> List()
        {
            return _RepositoryGame.List().ToList().Select(x => (GameResponse)x).ToList();
        }
    }
}
