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
        private readonly IServiceGame _serviceGame;
        private readonly IServicePlayer _servicePlayer;

        public ServiceMyGame(IRepositoryMyGame repositoryMyGame, IServiceGame serviceGame, IServicePlayer servicePlayer)
        {
            _repositoryMyGame = repositoryMyGame;
            _serviceGame = serviceGame;
            _servicePlayer = servicePlayer;
        }

        public MyGameResponse Create(CreateMyGameRequest request)
        {
            _servicePlayer.GetById(request.PlayerId);
            _serviceGame.GetById(request.GameId);

            var myGame = new MyGame(request.PlayerId, request.GameId);

            if (_repositoryMyGame.Exists(x => x.Player.Id == request.PlayerId && x.Game.Id == request.GameId))
            {
                throw new ValidationException("This game already exists for this player ");
            }
            var result = _repositoryMyGame.Create(myGame);
            result = _repositoryMyGame.List(x => x.Game, y => y.Player).Where(x => x.Id == result.Id).FirstOrDefault();

            return (MyGameResponse)result;
        }

        public IEnumerable<MyGameResponse> GetAll()
        {
            return _repositoryMyGame.List(x => x.Game, y => y.Player).ToList().Select(x => (MyGameResponse)x).ToList();
        }

        public MyGameResponse GetById(Guid id)
        {
            var result = ExistMyGame(id);
            result = _repositoryMyGame.List(x => x.Game, y => y.Player).Where(x => x.Id == result.Id).FirstOrDefault();

            return (MyGameResponse)result;
        }
        public MyGameResponse Update(Guid id, UpdateMyGameRequest request)
        {
            var myGame = ExistMyGame(id);

            _serviceGame.GetById(request.GameId);

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
            var result = _repositoryMyGame.Update(myGame);
            result = _repositoryMyGame.List(x => x.Game, y => y.Player).Where(x => x.Id == result.Id).FirstOrDefault();

            return (MyGameResponse)result;
        }

        public void Delete(Guid id)
        {
            var myGame = ExistMyGame(id);
            _repositoryMyGame.Delete(myGame);
        }

        private MyGame ExistMyGame(Guid id)
        {
            var myGame = _repositoryMyGame.GetById(id);
            if (myGame == null) throw new ValidationException("Id MyGame not found!");
            return myGame;
        }


    }
}
