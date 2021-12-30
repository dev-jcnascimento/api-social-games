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

        [Route("Add")]
        [HttpPost]
        public async Task<HttpResponseMessage> Add(AddPlatFormRequest request)
        {
            try
            {
                var response = _servicePlatForm.Add(request);
                return await ResponseAsync(response);
            }
            catch (Exception ex)
            {

                return await ResponseExceptionAsync(ex);
            }
        }
        [Route("Edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> Edit(ChancePlatFormRequest request)
        {
            try
            {
                var response = _servicePlatForm.Chance(request);
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
                var response = _servicePlatForm.List();
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