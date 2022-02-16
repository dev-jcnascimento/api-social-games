using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.MyGame;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Enum;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServiceMyGame : IServiceMyGame
    {
        private readonly IRepositoryMyGame _repositoryMyGame;
        private readonly IRepositoryGame _repositoryGame;

        public ServiceMyGame(IRepositoryMyGame repositoryMyGame, IRepositoryGame repositoryGame)
        {
            _repositoryMyGame = repositoryMyGame;
            _repositoryGame = repositoryGame;
        }

        public MyGameResponse Create(CreateMyGameRequest request)
        {
            var myGame = new MyGame(request.PlayerId, request.GameId);

            if (_repositoryMyGame.Exists(x => x.Player.Id == request.PlayerId && x.Game.Id == request.GameId))
            {
                throw new ValidationException("This game already exists for this player ");
            }
            myGame = _repositoryMyGame.Create(myGame);
            return (MyGameResponse)myGame;
        }
        public MyGameResponse Update(UpdateMyGameRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("UpdateMyGameRequest is required!");
            }

            MyGame myGame = _repositoryMyGame.GetById(request.Id);
            if (myGame == null)
            {
                throw new ValidationException("MyGame not found!");
            }

            var game = _repositoryMyGame.GetById(request.GameId);
            if (game == null)
            {
                throw new ValidationException("Game not found!");
            }
            var status = MyGameStatus.NewGame;

            switch (request.MyStatusGame.ToLower())
            {
                case "seeing":
                    status = MyGameStatus.Seeing;
                    break;
                case "wish":
                    status = MyGameStatus.Wish;
                    break;
            }

            myGame.Update(status, request.GameId);
            _repositoryMyGame.Update(myGame);

            return (MyGameResponse)myGame;
        }

        public IEnumerable<MyGameResponse> ListMyGame()
        {
            return _repositoryMyGame.List().ToList().Select(x => (MyGameResponse)x).ToList();
        }

        //public MyGameResponse GetById(Guid Id)
        //{
        //    var myGame = _repositoryMyGame.GetById(Id);

        //}

        public ResponseBase Delete(Guid id)
        {
            throw new NotImplementedException();
        }


    }
}
