using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Create(CreatePlatFormRequest request)
        {
            var response = _servicePlatForm.Create(request);
            Commit(response);
            return Request.CreateResponse(HttpStatusCode.Created, response);
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = _servicePlatForm.GetAll();
            Commit(response);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            var response = _servicePlatForm.GetById(id);
            Commit(response);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, UpdatePlatFormRequest request)
        {
            var response = _servicePlatForm.Update(id, request);
            Commit(response);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            var response = _servicePlatForm.Delete(id);
            Commit(response);
            return Request.CreateResponse(HttpStatusCode.NoContent, response);
        }
    }
}