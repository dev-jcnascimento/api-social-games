using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Extensions;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServicePlayer : IServicePlayer
    {
        private readonly IRepositoryPlayer _repositoryPlayer;

        public ServicePlayer(IRepositoryPlayer repositoryPlayer)
        {
            _repositoryPlayer = repositoryPlayer;
        }

        public AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request)
        {
            if (request == null)
            {
                throw new ValidationException("AuthenticatePlayerRequest is required!");
            }

            var player = _repositoryPlayer.GetBy(
                x => x.Email.Address == request.Email &&
                x.Password.Word == request.Password.ConvertToMD5());
            return (AuthenticatePlayerResponse)player;
        }

        public PlayerResponse Create(CreatePlayerRequest request)
        {
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email.ToString().Replace("%40", "@"));
            var password = new Password(request.Password);

            Player player = new Player(name, email, password);
            if (_repositoryPlayer.Exists(x => x.Email.Address == request.Email))
            {
                throw new ValidationException("This User already exists!");
            }

            var result = _repositoryPlayer.Create(player);
            return (PlayerResponse)result;
        }

        public IEnumerable<PlayerResponse> GetAll()
        {
            return _repositoryPlayer.List().ToList().Select(x => (PlayerResponse)x).ToList();
        }

        public PlayerResponse GetById(Guid id)
        {
            var player = ExistPlayer(id);

            return (PlayerResponse)player;
        }

        public PlayerResponse UpdateAdmin(Guid id, UpdateAdminPlayerRequest request)
        {
            var player = ExistPlayer(id);

            player.UpdatePlayerAdmin();
            _repositoryPlayer.Update(player);

            return (PlayerResponse)player;
        }
        public PlayerResponse Update(Guid id, UpdatePlayerRequest request)
        {
            var player = ExistPlayer(id);

            var email = new Email(request.Email);
            var name = new Name(request.FirstName, request.LastName);

            player.UpdatePlayer(name, email, player.Status);
            var result = _repositoryPlayer.Update(player);

            return (PlayerResponse)result;
        }
        public void Delete(Guid id)
        {
            var player = ExistPlayer(id);

            _repositoryPlayer.Delete(player);
        }

        private Player ExistPlayer(Guid id)
        {
            var player = _repositoryPlayer.GetById(id);
            if (player == null) throw new ValidationException("Id Player not found!");
            return player;
        }
    }
}
