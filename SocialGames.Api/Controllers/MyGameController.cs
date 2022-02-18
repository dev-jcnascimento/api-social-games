using Canducci.Pagination;
using SocialGames.Domain.Arguments.MyGame;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{

    [RoutePrefix("v1/myGames")]
    public class MyGameController : ApiController
    {
        private readonly IServiceMyGame _serviceMyGame;

        public MyGameController(IServiceMyGame serviceMyGame)
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
                return Request.CreateResponse(HttpStatusCode.Created, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll(int page = 1, int size = 5)
        {
            var response = _serviceMyGame.GetAll().ToPaginated(page, size);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _serviceMyGame.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("getBy/{playerId}")]
        [HttpGet]
        public HttpResponseMessage GetByPlayerId(Guid playerId, int page = 1, int size = 5)
        {
            try
            {
                var response = _serviceMyGame.GetByPlayerId(playerId).ToPaginated(page, size);
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
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}