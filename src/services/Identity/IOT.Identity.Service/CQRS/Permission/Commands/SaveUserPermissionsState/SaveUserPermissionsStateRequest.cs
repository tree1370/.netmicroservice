using IOT.Identity.Domain.Core;
using IOT.Identity.Service.User.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.Permission.Queries.GetUserPermissions
{
    public class SaveUserPermissionsStateRequest : IRequest<bool>
    {
        public UserId UserId { get; set; }
    }
}
