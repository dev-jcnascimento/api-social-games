using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Domain.Arguments.Base
{
    internal class ResponseBase
    {
        public string Message { get; set; }
        public ResponseBase()
        {
            Message = ("Operação realizada com Sucesso!");
        }

        public static explicit operator ResponseBase(Entities.Player entity)
        {
            return new ResponseBase()
            {
                Message = ("Operação realizada com Sucesso!")
            };
        }
    }
}
