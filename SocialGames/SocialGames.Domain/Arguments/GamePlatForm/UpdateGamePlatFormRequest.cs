using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Arguments.GamePlatForm
{
    public class UpdateGamePlatFormRequest
    {
        public string Game { get; set; }
        public string PlatForm { get; set; }
    }
}
