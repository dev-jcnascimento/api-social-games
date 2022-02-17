using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.PlatForm;
using SocialGames.Domain.Entities;
using SocialGames.Domain.Interfaces.Repositories;
using SocialGames.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public PlatFormResponse Create(CreatePlatFormRequest request)
        {
            PlatForm platForm = new PlatForm(request.Name);
            if (_repositoryPlatForm.Exists(
                x => x.Name.ToString().ToLower().Replace(" ", "") == 
                request.Name.ToString().ToLower().Replace(" ", "")))
            {
                throw new ValidationException("This PlatForm already exists!");
            }
            platForm = _repositoryPlatForm.Create(platForm);

            return (PlatFormResponse)platForm;

        }

        public IEnumerable<PlatFormResponse> GetAll()
        {
            return _repositoryPlatForm.List().ToList().Select(x => (PlatFormResponse)x).ToList();
        }

        public PlatFormResponse GetById(Guid id)
        {
            var platForm = ExistPlatForm(id);

            return (PlatFormResponse)platForm;
        }

        public PlatFormResponse Update(Guid id, UpdatePlatFormRequest request)
        {
            var platForm = ExistPlatForm(id);

            platForm.ChancePlatForm(request.Name);
            _repositoryPlatForm.Update(platForm);

            return (PlatFormResponse)platForm;
        }
        public ResponseBase Delete(Guid id)
        {
           var platForm = ExistPlatForm(id);

            _repositoryPlatForm.Delete(platForm);  

            return (ResponseBase)platForm;
        }

        private PlatForm ExistPlatForm(Guid id)
        {
            var platForm = _repositoryPlatForm.GetById(id);

            if (platForm == null) throw new ValidationException("Id PlatForm not Found");

            return platForm;
        }
    }
}
