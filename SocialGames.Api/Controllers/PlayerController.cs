using Canducci.Pagination;
using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{

    [RoutePrefix("v1/players")]
    public class PlayerController : ControllerBase
    {
        private readonly IServicePlayer _servicePlayer;

        public PlayerController(IUnitOfWork unitOfWork, IServicePlayer servicePlayer) : base(unitOfWork)
        {
            _servicePlayer = servicePlayer;
        }
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreatePlayerRequest request)
        {
            var response = _servicePlayer.Create(request);
            return await ResponseAsync(response);
        }
        [Route("admin")]
        [HttpPatch]
        public async Task<HttpResponseMessage> EditAdmin(UpdateAdminPlayerRequest request)
        {
            var response = _servicePlayer.UpdateAdmin(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdatePlayerRequest request)
        {
            var response = _servicePlayer.Update(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> List(int? page,int? size)
        {
            if (page <= 0) page = 1;
            if (size <= 0) size = 1;

            var response = _servicePlayer.GetAllPlayers();
            return await ResponseAsync(response.ToPaginated((int)page, (int)size));
        }
        
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = _servicePlayer.Delete(id);
            return await ResponseAsync(response);
        }
    }
}
