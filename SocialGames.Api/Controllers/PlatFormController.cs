using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{
    [RoutePrefix("v1/platforms")]
    public class PlatFormController : ControllerBase
    {
        private readonly IServicePlatForm _servicePlatForm;
        public PlatFormController(IUnitOfWork unitOfWork, IServicePlatForm servicePlatForm) : base(unitOfWork)
        {
            _servicePlatForm = servicePlatForm;

        }
        [Route("")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreatePlatFormRequest request)
        {
            var response = _servicePlatForm.Create(request);
            return await ResponseAsync(response);
        }
        [Route("")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdatePlatFormRequest request)
        {

            var response = _servicePlatForm.Update(request);
            return await ResponseAsync(response);

        }
        [Route("")]
        [HttpGet]
        public async Task<HttpResponseMessage> List()
        {
            var response = _servicePlatForm.List();
            return await ResponseAsync(response);
        }
        [Route("{id}")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(Guid id)
        {
            var response = _servicePlatForm.Delete(id);
            return await ResponseAsync(response);
        }
    }
}