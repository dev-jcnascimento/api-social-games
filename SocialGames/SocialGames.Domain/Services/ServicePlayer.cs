using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Services
{
    internal class ServicePlayer : IServicePlayer
    {
        public readonly IRepositoryPlayer _repositoryPlayer;

        public ServicePlayer(IRepositoryPlayer repositoryPlayer)
        {
            _repositoryPlayer = repositoryPlayer;
        }

        public AddPlayerResponse Add(AddPlayerRequest request)
        {
            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
            var password = new Password(request.Password);

            Player player = new Player(name, email, password, Enum.Status.EmAnlise);
            if (_repositoryPlayer.Existe(x => x.Email.Address == request.Email))
            { 
                throw new Exception("Esse Usuário já existe!");
            }
            Guid Id = _repositoryPlayer.Add(player);
            return new AddPlayerResponse() { Id = Id, Message = "Operação Realizada com Sucesso" };
        }

        public AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request)
        {
            if (request == null)
            {
                throw new Exception("AuthenticatePlayerRequest é obrigatório!");
            }
            var response = _repositoryPlayer.Authenticate(request);
            return response;

        }


    }
}
