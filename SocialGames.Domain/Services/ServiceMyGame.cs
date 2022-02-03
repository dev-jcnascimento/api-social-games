using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.MyGame;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Services
{
    public class ServiceMyGame : IServiceMyGame
    {
        private readonly IRepositoryMyGame _repositoryMyGame;

        public ServiceMyGame(IRepositoryMyGame repositoryMyGame)
        {
            _repositoryMyGame = repositoryMyGame;
        }

        public CreateMyGameResponse Create(CreateMyGameRequest request)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyGameResponse> ListMyGame()
        {
            throw new NotImplementedException();
        }

        public UpdateMyGameResponse Update(UpdateMyGameRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
