using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.GamePlatForm;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;


namespace SocialGames.Api.Controllers
{
    [RoutePrefix("v1/gamePlatForms")]
    public class GamePlatFormController : ControllerBase
    {
        private readonly IServiceGamePlatForm _serviceGamePlatForm;

        public GamePlatFormController(IUnitOfWork unitOfWork, IServiceGamePlatForm serviceGamePlatForm) : base(unitOfWork)
        {
            _serviceGamePlatForm = serviceGamePlatForm;
        }
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateGamePlatFormRequest request)
        {
            var response = _serviceGamePlatForm.Create(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdateGamePlatFormRequest request)
        {
            var response = _serviceGamePlatForm.Update(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            var response = _serviceGamePlatForm.GetAll();
            return await ResponseAsync(response);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = _serviceGamePlatForm.Delete(id);
            return await ResponseAsync(response);

        }
    }
}
