using SocialGames.Infra.Transactions;
using System;
using System.ComponentModel.DataAnnotations;
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
        public void Commit(object result)
        {
            if (result != null)
            {
                try
                {
                    _unitOfWork.Commit();
                }
                catch (Exception)
                {
                    throw new ValidationException($"Error adding/Request");
                }
            }
        }
    }
}
