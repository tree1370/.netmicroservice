using IOT.Identity.Service.User.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.Permission.Queries.GetUserPermissions
{
    public class GetUserPermissionsRequest : IRequest<List<UserPermissionDto>>
    {
        public string UserId { get; set; }
    }
}
