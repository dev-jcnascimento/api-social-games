using SocialGames.Domain.Interfaces.Arguments;

namespace SocialGames.Domain.Arguments.Player
{
    public class AddPlayerResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AddPlayerResponse(Entities.Player entity)
        {
            return new AddPlayerResponse()
            {
                Id = entity.Id,
                Message = "Operação realizada com Sucesso",
            };
        }
    }
}
