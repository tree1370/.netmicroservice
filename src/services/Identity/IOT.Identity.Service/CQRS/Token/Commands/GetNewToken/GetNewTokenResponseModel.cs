using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.Token.Commands.GetNewToken
{
    public class GetNewTokenResponseModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
