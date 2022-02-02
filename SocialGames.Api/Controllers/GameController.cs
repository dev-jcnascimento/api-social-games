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
    [RoutePrefix("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IServiceGame _serviceGame;
        public GameController(IUnitOfWork unitOfWork, IServiceGame serviceGame) : base(unitOfWork)
        {
            _serviceGame = serviceGame; 
        }
        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateGameRequest request)
        {
            try
            {
                var response = _serviceGame.Create(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateGameRequest request)
        {
            try
            {
                var response = _serviceGame.Update(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("read")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            try
            {
                var response = _serviceGame.List();
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _serviceGame.Delete(id);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
    }
}