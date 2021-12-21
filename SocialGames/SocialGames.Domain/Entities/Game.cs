using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Entities
{
    internal class Game : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Producer { get; private set; }
        public string Gender { get; private set; }
        public string Distributor { get; private set; }
    }
}
