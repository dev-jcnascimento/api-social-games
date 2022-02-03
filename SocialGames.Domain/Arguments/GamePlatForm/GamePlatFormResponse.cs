using SocialGames.Domain.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Arguments.GamePlatForm
{
    public class GamePlatFormResponse : ResponseBase
    {
        public Guid Id { get; set; }
        public string Game { get; set; }
        public string PlatForm { get; set; }
    }
}
