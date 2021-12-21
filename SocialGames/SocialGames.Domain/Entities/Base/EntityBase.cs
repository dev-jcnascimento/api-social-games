using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Entities.Base
{
    internal abstract class EntityBase
    {
        public Guid Id { get; private set; }
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
