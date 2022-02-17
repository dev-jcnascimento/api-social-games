using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Arguments.PlatForm;
using System;
using System.Collections.Generic;

namespace SocialGames.Domain.Interfaces.Services
{
    public interface IServicePlatForm
    {
        PlatFormResponse Create(CreatePlatFormRequest request);
        IEnumerable<PlatFormResponse> GetAll();
        PlatFormResponse GetById(Guid id);
        PlatFormResponse Update(Guid id,UpdatePlatFormRequest request);
        ResponseBase Delete(Guid id);
    }
}
