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
        [Route("Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddGameRequest request)
        {
            try
            {
                var response = _serviceGame.Add(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(ChanceGameRequest request)
        {
            try
            {
                var response = _serviceGame.Chance(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("Get")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
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
        [Route("Delete")]
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