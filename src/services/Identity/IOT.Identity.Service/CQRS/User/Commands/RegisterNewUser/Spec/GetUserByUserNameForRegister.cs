using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IOT.Identity.Service.CQRS.User.Commands.RegisterNewUser.Spec
{
    public class GetUserByUserNameForRegister : Specification<Domain.Core.User>, ISingleResultSpecification
    {
        public GetUserByUserNameForRegister(string userName) =>
           Query.Where(p => p.UserName == userName);
    }
}
