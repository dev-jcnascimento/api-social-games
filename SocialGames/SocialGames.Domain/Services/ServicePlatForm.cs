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
        public readonly IRepositoryPlatForm _repositoryPlatForm;

        public ServicePlatForm(IRepositoryPlatForm repositoryPlatForm)
        {
            _repositoryPlatForm = repositoryPlatForm;
        }

        public AddPlatFormResponse Add(AddPlatFormRequest request)
        {

            PlatForm platForm = new PlatForm(request.Name);
            if (_repositoryPlatForm.Exists(x => x.Name == request.Name))
            {
                throw new Exception("This PlatForm already exists!");
            }
            platForm = _repositoryPlatForm.Add(platForm);
            return (AddPlatFormResponse)platForm;

        }

        public ChancePlatFormResponse Chance(ChancePlatFormRequest request)
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

            platForm.ChancePlatForm(platForm.Name);
            _repositoryPlatForm.Edit(platForm);

            return (ChancePlatFormResponse)platForm;
        }
        public ResponseBase DeletePlayer(Guid id)
        {
            PlatForm platForm = _repositoryPlatForm.GetById(id);
            if (platForm == null)
            {
                throw new Exception("PlatForm not found!");
            }
            _repositoryPlatForm.Remove(platForm);  

            return (ResponseBase)platForm;
        }

        public IEnumerable<PlatFormResponse> ListPlayers()
        {
            return _repositoryPlatForm.List().ToList().Select(x => (PlatFormResponse)x).ToList();
        }
    }
}
