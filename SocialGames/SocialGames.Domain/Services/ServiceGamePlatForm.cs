using SocialGames.Domain.Arguments.GamePlatForm;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServiceGamePlatForm : IServiceGamePlatForm
    {
        private readonly IRepositoryGamePlatForm _repositoryGamePlatForm;
        private readonly IRepositoryGame _repositoryGame;
        private readonly IRepositoryPlatForm _repositoryPlatForm;

        public ServiceGamePlatForm(IRepositoryGamePlatForm repositoryGamePlatForm, IRepositoryGame repositoryGame, IRepositoryPlatForm repositoryPlatForm)
        {
            _repositoryGamePlatForm = repositoryGamePlatForm;
            _repositoryGame = repositoryGame;
            _repositoryPlatForm = repositoryPlatForm;
        }

        public CreateGamePlatFormResponse Create(CreateGamePlatFormRequest request)
        {
            if (request == null)
            {
                throw new Exception("Request is Necessary!");
            }
            if (_repositoryGamePlatForm.Exists(x => x.Game.Id == request.GameId))
            {

            }


            if (_repositoryGame.Exists(x => x.Id == request.GameId)
            && _repositoryPlatForm.Exists(x => x.Id == request.PlatFormId))
            {
                DateTime dateTime = DateTime.Now;
                Game game = _repositoryGame.GetById(request.GameId);
                PlatForm platForm = _repositoryPlatForm.GetById(request.PlatFormId);

                GamePlatForm gamePlatForm = new GamePlatForm(dateTime, game, platForm);
                gamePlatForm = _repositoryGamePlatForm.Create(gamePlatForm);
                return (CreateGamePlatFormResponse)gamePlatForm;
            }
            else
            {
                throw new Exception("Request not found!");
            }
        }

        public GamePlatFormResponse Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GamePlatFormResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdateGamePlatFormResponse Update(UpdateGamePlatFormRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
