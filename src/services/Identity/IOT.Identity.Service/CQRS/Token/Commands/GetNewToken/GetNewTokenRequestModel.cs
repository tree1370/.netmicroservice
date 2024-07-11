using IOT.Identity.Service.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.Token.Commands.GetNewToken
{
    public class GetNewTokenRequestModel : IRequest<GetNewTokenResponseModel>
    {
        public string RefreshToken { get; set; }
    }
}
