using SocialGames.Infra.Transactions;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace SocialGames.Api.Controllers.Base
{
    public class ControllerBase : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HttpResponseMessage> ResponseAsync(object result)
        {
            if (result != null)
            {
                try
                {

                    _unitOfWork.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, $"Error adding/Request");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { erros = "Error Request." });
            }

        }
        public async Task<HttpResponseMessage> ResponseExceptionAsync(Exception ex)
        {
            return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = ex.Message, exception = ex.ToString() });
        }
    }
}
