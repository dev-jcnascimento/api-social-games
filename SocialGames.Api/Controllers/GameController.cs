using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.Game;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{
    [RoutePrefix("v1/games")]
    public class GameController : ControllerBase
    {
        private readonly IServiceGame _serviceGame;
        public GameController(IUnitOfWork unitOfWork, IServiceGame serviceGame) : base(unitOfWork)
        {
            _serviceGame = serviceGame;
        }
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateGameRequest request)
        {
            var response = _serviceGame.Create(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateGameRequest request)
        {
            var response = _serviceGame.Update(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            var response = _serviceGame.List();
            return await ResponseAsync(response);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = _serviceGame.Delete(id);
            return await ResponseAsync(response);

        }
    }
}