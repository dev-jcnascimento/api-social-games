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
    [RoutePrefix("api/player")]
    public class PlayerController : ControllerBase
    {
        private readonly IServicePlayer _servicePlayer;

        public PlayerController(IUnitOfWork unitOfWork, IServicePlayer servicePlayer) : base(unitOfWork)
        {
            _servicePlayer = servicePlayer;
        }
        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreatePlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.Create(request);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("update/admin")]
        [HttpPatch]
        public async Task<HttpResponseMessage> EditAdmin(UpdateAdminPlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.UpdateAdmin(request);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdatePlayerRequest request)
        {
            try
            {

                var response = _servicePlayer.Update(request);

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
                var response = _servicePlayer.ListPlayers();

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Authorize]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {
                var response = _servicePlayer.Delete(id);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
