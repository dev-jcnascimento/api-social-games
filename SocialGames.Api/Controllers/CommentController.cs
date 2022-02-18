using Canducci.Pagination;
using SocialGames.Domain.Arguments.Comment;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialGames.Api.Controllers
{
    [RoutePrefix("v1/comments")]
    public class CommentController : ApiController
    {
        private readonly IServiceComment _serviceComment;

        public CommentController(IServiceComment serviceComment)
        {
            _serviceComment = serviceComment;
        }
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Create(CreateCommentRequest request)
        {
            try
            {
                var response = _serviceComment.Create(request);
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
            var response = _serviceComment.GetAll().ToPaginated(page, size);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetById(Guid id)
        {
            try
            {
                var response = _serviceComment.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [Route("getBy/{gameId}")]
        [HttpGet]
        public HttpResponseMessage GetByGameId(Guid gameId)
        {
            try
            {
                var response = _serviceComment.GetByGameId(gameId);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
        [Route("getBy/{playerId}")]
        [HttpGet]
        public HttpResponseMessage GetByPlayerId(Guid playerId)
        {
            try
            {
                var response = _serviceComment.GetByPlayerId(playerId);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Guid id, UpdateCommentRequest request)
        {
            try
            {
                var response = _serviceComment.Update(id, request);
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
                _serviceComment.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (ValidationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}