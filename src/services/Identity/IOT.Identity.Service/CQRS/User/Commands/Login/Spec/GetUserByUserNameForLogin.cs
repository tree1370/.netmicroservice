using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IOT.Identity.Service.CQRS.User.Commands.Login.Spec
{
    public class GetUserByUserNameForLogin : Specification<Domain.Core.User>, ISingleResultSpecification
    {
        //public GetUserByUserNameForLogin(string userName) =>
        //   Query.Where(p => p.UserName == userName);
    }
}
