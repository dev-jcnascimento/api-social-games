using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Entities
{
    internal class Platform : EntityBase
    {
        public string Name { get; private set; }
    }
}
