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


        public PlayerController(IUnitOfWork unitOfWork,IServicePlayer servicePlayer): base(unitOfWork)
        {
            _servicePlayer = servicePlayer;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddPlayerRequest request)
        {
            try
            {

                var response = _servicePlayer.Add(request);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("EditAdmin")]
        [HttpPatch]
        public async Task<HttpResponseMessage> EditAdmin(ChanceAdminPlayerRequest request)
        {
            try
            {

                var response = _servicePlayer.ChanceAdmin(request);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(ChancePlayerRequest request)
        {
            try
            {

                var response = _servicePlayer.Chance(request);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Authorize]
        [Route("Delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            try
            {

                var response = _servicePlayer.DeletePlayer(id);

                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("List")]
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
    }
}
