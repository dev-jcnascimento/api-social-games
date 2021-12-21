using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.ValueObject
{
    internal class Name
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
