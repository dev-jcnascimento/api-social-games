using SocialGames.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Entities
{
    internal class MyGames : EntityBase
    {
        public DateTime Date { get; private set; }
        public string Seeing { get; private set; }
        public string Change { get; private set; }
        public string Wish { get; private set; }
    }
}
