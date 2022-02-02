using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{
    [RoutePrefix("api/platform")]
    public class PlatFormController : ControllerBase
    {
        private readonly IServicePlatForm _servicePlatForm;
        public PlatFormController(IUnitOfWork unitOfWork, IServicePlatForm servicePlatForm) : base(unitOfWork)
        {
            _servicePlatForm = servicePlatForm;
        }
        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> Create(CreatePlatFormRequest request)
        {
            try
            {
                var response = _servicePlatForm.Create(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("update")]
        [HttpPut]
        public async Task<HttpResponseMessage> Update(UpdatePlatFormRequest request)
        {
            try
            {
                var response = _servicePlatForm.Update(request);
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
                var response = _servicePlatForm.List();
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
                var response = _servicePlatForm.Delete(id);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }

    }
}