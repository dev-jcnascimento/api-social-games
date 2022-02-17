using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.ComponentModel.DataAnnotations;
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
            try
            {
                var response = _servicePlatForm.Create(request);
                Commit();
                return Request.CreateResponse(HttpStatusCode.Created, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var response = _servicePlatForm.GetAll();
            Commit();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _servicePlatForm.GetById(id);
                Commit();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, UpdatePlatFormRequest request)
        {
            try
            {
                var response = _servicePlatForm.Update(id, request);
                Commit();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _servicePlatForm.Delete(id);
                Commit();
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
