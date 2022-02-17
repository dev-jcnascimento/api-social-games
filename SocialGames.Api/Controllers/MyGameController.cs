using SocialGames.Api.Controllers.Base;
using SocialGames.Domain.Arguments.MyGame;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Infra.Transactions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{

    [RoutePrefix("v1/myGames")]
    public class MyGameController : ControllerBase
    {
        private readonly IServiceMyGame _serviceMyGame;

        public MyGameController(IUnitOfWork unitOfWork, IServiceMyGame serviceMyGame) : base(unitOfWork)
        {
            _serviceMyGame = serviceMyGame;
        }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create(CreateMyGameRequest request)
        {
            try
            {
                var response = _serviceMyGame.Create(request);
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
            var response = _serviceMyGame.GetAll();
            Commit();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _serviceMyGame.GetById(id);
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
        public HttpResponseMessage Update(Guid id, UpdateMyGameRequest request)
        {
            try
            {
                var response = _serviceMyGame.Update(id, request);
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
                _serviceMyGame.Delete(id);
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