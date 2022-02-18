using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{

    [RoutePrefix("v1/players")]
    public class PlayerController : ApiController
    {
        private readonly IServicePlayer _servicePlayer;

        public PlayerController(IServicePlayer servicePlayer)
        {
            _servicePlayer = servicePlayer;
        }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create(CreatePlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.Create(request);
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
            var response = _servicePlayer.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _servicePlayer.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("updateAdmin/{id}")]
        [HttpPut]
        public HttpResponseMessage UpdateAdmin(Guid id, UpdateAdminPlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.UpdateAdmin(id, request);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, UpdatePlayerRequest request)
        {
            try
            {
                var response = _servicePlayer.Update(id, request);
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
                _servicePlayer.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
