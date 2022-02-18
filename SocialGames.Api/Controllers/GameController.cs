using SocialGames.Domain.Arguments.Game;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{
    [RoutePrefix("v1/games")]
    public class GameController : ApiController
    {
        private readonly IServiceGame _serviceGame;
        public GameController(IServiceGame serviceGame)
        {
            _serviceGame = serviceGame;
        }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create(CreateGameRequest request)
        {
            try
            {
                var response = _serviceGame.Create(request);
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
            var response = _serviceGame.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _serviceGame.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, UpdateGameRequest request)
        {
            try
            {
                var response = _serviceGame.Update(id, request);
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
                _serviceGame.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}