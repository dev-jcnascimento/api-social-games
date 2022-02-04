using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.MyGame;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{

    [RoutePrefix("v1/myGames")]
    public class MyGameController : ControllerBase
    {
        private readonly IServiceMyGame _serviceMyGame;

        public MyGameController(IUnitOfWork unitOfWork, IServiceMyGame serviceMyGame) : base(unitOfWork)
        {
            _serviceMyGame = serviceMyGame;
        }
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateMyGameRequest request)
        {
            var response = _serviceMyGame.Create(request);
            return await ResponseAsync(response);
        }

        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateMyGameRequest request)
        {
            var response = _serviceMyGame.Update(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            var response = _serviceMyGame.ListMyGame();
            return await ResponseAsync(response);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = _serviceMyGame.Delete(id);
            return await ResponseAsync(response);
        }

    }
}