using Ardalis.Specification;
using IOT.Identity.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IOT.Identity.Service.CQRS.Token.Commands.GetNewToken.Spec
{
    public class RefreshTokenByGetCurrentToken : Specification<UserRefreshToken>, ISingleResultSpecification
    {
        public RefreshTokenByGetCurrentToken(string currentToken) =>
            Query.Where(p => p.RefreshToken == currentToken);
    }
}
