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
    [RoutePrefix("api/gamePlatForm")]
    public class GamePlatFormController : ControllerBase
    {
        private readonly IServiceGamePlatForm _serviceGamePlatForm;

        public GamePlatFormController(IUnitOfWork unitOfWork, IServiceGamePlatForm serviceGamePlatForm) : base(unitOfWork)
        {
            _serviceGamePlatForm = serviceGamePlatForm;
        }
        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreateGamePlatFormRequest request)
        {
            try
            {
                var response = _serviceGamePlatForm.Create(request);

                return await ResponseAsync(response);
            }
            catch(Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}
