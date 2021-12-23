using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Domain.ValueObject;

namespace SocialGames.Domain.Services
{
    public class ServicePlayer : IServicePlayer
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

            Player player = new(name, email, password);
            if (_repositoryPlayer.Existe(x => x.Email.Address == request.Email))
            {
                throw new Exception("Esse Usuário já existe!");
            }
            player = _repositoryPlayer.Adicionar(player);
            return (AddPlayerResponse)player;

        }

        public AuthenticatePlayerResponse Authenticate(AuthenticatePlayerRequest request)
        {
            if (request == null)
            {
                throw new Exception("AuthenticatePlayerRequest é obrigatório!");
            }

            var email = new Email(request.Email);
            var password = new Password(request.Password);
            var player = new Player(email, password);

            player = _repositoryPlayer.ObterPor(
                x => x.Email.Address == player.Email.Address &&
                x.Password.Word == player.Password.Word);
            return (AuthenticatePlayerResponse)player;

        }

        public ChancePlayerResponse Chance(ChancePlayerRequest request)
        {
            if (request == null)
            {
                throw new Exception("ChancePlayerRequest é obrigatório!");
            }

            Player player = _repositoryPlayer.ObterPorId(request.Id);
            if (player == null)
            {
                throw new Exception("Jogador não encontrado!");
            }
            var email = new Email(request.Email);
            var name = new Name(request.FirstName, request.LastName);

            player.ChancePlayer(name, email, player.Status);
            _repositoryPlayer.Editar(player);

            return (ChancePlayerResponse)player;
        }

        public ResponseBase DeletePlayer(Guid id)
        {
            Player player = _repositoryPlayer.ObterPorId(id);
            if (player == null)
            {
                throw new Exception("Jogador não encontrado!");
            }
            _repositoryPlayer.Remover(player);  

            return (ResponseBase)player;
        }

        public IEnumerable<PlayerResponse> ListPlayers()
        {
            return _repositoryPlayer.Listar().ToList().Select(x => (PlayerResponse)x).ToList();
        }
    }
}
