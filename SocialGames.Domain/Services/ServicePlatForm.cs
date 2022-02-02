using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Arguments.Player;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using SocialGames.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialGames.Domain.Services
{
    public class ServicePlatForm : IServicePlatForm
    {
        private readonly IRepositoryPlatForm _repositoryPlatForm;

        public ServicePlatForm(IRepositoryPlatForm repositoryPlatForm)
        {
            _repositoryPlatForm = repositoryPlatForm;
        }

        public CreatePlatFormResponse Create(CreatePlatFormRequest request)
        {
            PlatForm platForm = new PlatForm(request.Name);
            if (_repositoryPlatForm.Exists(
                x => x.Name.ToString().ToLower().Replace(" ", "") == 
                request.Name.ToString().ToLower().Replace(" ", "")))
            {
                throw new Exception("This PlatForm already exists!");
            }
            platForm = _repositoryPlatForm.Create(platForm);
            return (CreatePlatFormResponse)platForm;

        }

        public UpdatePlatFormResponse Update(UpdatePlatFormRequest request)
        {
            if (request == null)
            {
                throw new Exception("ChancePlatFormRequest is required!");
            }

            PlatForm platForm = _repositoryPlatForm.GetById(request.Id);
            if (platForm == null)
            {
                throw new Exception("PlatForm not found!");
            }

            platForm.ChancePlatForm(request.Name);
            _repositoryPlatForm.Update(platForm);

            return (UpdatePlatFormResponse)platForm;
        }
        public ResponseBase Delete(Guid id)
        {
            PlatForm platForm = _repositoryPlatForm.GetById(id);
            if (platForm == null)
            {
                throw new Exception("PlatForm not found!");
            }
            _repositoryPlatForm.Delete(platForm);  

            return (ResponseBase)platForm;
        }

        public IEnumerable<PlatFormResponse> List()
        {
            return _repositoryPlatForm.List().ToList().Select(x => (PlatFormResponse)x).ToList();
        }
    }
}
