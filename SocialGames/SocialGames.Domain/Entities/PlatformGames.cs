using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Entities
{
    internal class PlatformGames : EntityBase
    {
        public DateTime Date { get; private set; }
        public Game Game { get; private set; }
        public Platform Platform { get; private set; }
    }
}
