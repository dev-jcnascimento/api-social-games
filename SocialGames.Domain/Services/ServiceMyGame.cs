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
        private readonly IRepositoryPlayer _repositoryPlayer;
        private readonly IServiceGame _serviceGame;
        private readonly IServicePlayer _servicePlayer;
        private readonly IServicePlatForm _servicePlatForm;

        public ServiceMyGame(IRepositoryMyGame repositoryMyGame, IRepositoryGame repositoryGame, IRepositoryPlayer repositoryPlayer, IServiceGame serviceGame, IServicePlayer servicePlayer, IServicePlatForm servicePlatForm)
        {
            _repositoryMyGame = repositoryMyGame;
            _repositoryGame = repositoryGame;
            _repositoryPlayer = repositoryPlayer;
            _serviceGame = serviceGame;
            _servicePlayer = servicePlayer;
            _servicePlatForm = servicePlatForm;
        }

        public MyGameResponse Create(CreateMyGameRequest request)
        {
          
            var myGame = new MyGame(request.PlayerId, request.GameId);

            if (_repositoryMyGame.Exists(x => x.Player.Id == request.PlayerId && x.Game.Id == request.GameId))
            {
                throw new ValidationException("This game already exists for this player ");
            }
            var result = _repositoryMyGame.Create(myGame);

            return GetByMyGame(result.Id);
        }

        public IEnumerable<MyGameResponse> GetAll()
        {
            var myGames = _repositoryMyGame.List().ToList();

            List<MyGameResponse> listMyGame = new List<MyGameResponse>();
            foreach (var myGame in myGames)
            {
                var myGameResult = GetByMyGame(myGame.Id);
                listMyGame.Add(myGameResult);
            }
            return listMyGame;
        }

        public MyGameResponse GetById(Guid id)
        {
            return GetByMyGame(id);
        }
        public IEnumerable<MyGameResponse> GetByPlayerId(Guid playerId)
        {
            _servicePlayer.GetById(playerId);
            var allMyGames = _repositoryMyGame.List(x => x.Game, y => y.Player).Where(x => x.PlayerId == playerId).ToList();
            List<MyGameResponse> listMyGame = new List<MyGameResponse>();
            foreach (var myGame in allMyGames)
            {
                var platform = _servicePlatForm.GetById(myGame.Game.PlatFormId);
                listMyGame.Add(new MyGameResponse()
                {
                    Id = myGame.Id,
                    Date = myGame.Date.ToString(),
                    PlayerName = myGame.Player.Name.ToString(),
                    GameName = myGame.Game.Name.ToString(),
                    StatusGame = myGame.MyGameStatus.ToString(),
                    PlatformName = platform.Name,
                });
            }
            return listMyGame;
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
        private void ExistPlayer(Guid playerId)
        {
            if (_repositoryPlayer.GetById(playerId) == null) throw new ValidationException("Id Player not found!");
        }
        private void ExistGame(Guid gameId)
        {
            if (_repositoryGame.GetById(gameId) == null) throw new ValidationException("Id Game not found!");
        }
        private MyGame ExistMyGame(Guid id)
        {
            var myGame = _repositoryMyGame.GetById(id);
            if (myGame == null) throw new ValidationException("Id MyGame not found!");
            return myGame;
        }
        private MyGameResponse GetByMyGame(Guid myGameId)
        {
            var myGame = ExistMyGame(myGameId);
            var player = _repositoryPlayer.GetById(myGame.PlayerId);
            var game = _repositoryGame.List(x => x.PlatForm).ToList().Where(x => x.Id == myGame.GameId).ToList().FirstOrDefault();

            var myGameResponse = new MyGameResponse()
            {
                Id = myGameId,
                Date = myGame.Date.ToString(),
                PlayerId = myGame.PlayerId,
                PlayerName = player.Name.ToString(),
                GameName = game.Name,
                GameId = myGame.GameId,
                StatusGame = myGame.MyGameStatus.ToString(),
                PlatformId = game.PlatFormId,
                PlatformName = game.PlatForm.Name.ToString(),
            };
            return myGameResponse;
        }

    }
}
