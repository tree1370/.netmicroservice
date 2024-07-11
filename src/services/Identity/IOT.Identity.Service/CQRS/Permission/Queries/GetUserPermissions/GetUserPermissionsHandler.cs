using Buildin.Blocks.Application.Security.Utility;
using Building.Blocks.Core.Exception.Types;
using Dapr.Client;
using Google.Api;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.CQRS.User.Commands.Login.Spec;
using IOT.Identity.Service.User.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IOT.Identity.Service.CQRS.Permission.Queries.GetUserPermissions
{
    public class GetUserPermissionsHandler : IRequestHandler<GetUserPermissionsRequest, List<UserPermissionDto>>
    {

        private readonly Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> _user;
        private readonly EncryptionUtility _encryptionUtility;
        private readonly IMediator _mediator;
        private readonly ILogger<GetUserPermissionsHandler> _logger;
        private const string DAPR_STORE_NAME = "statestore";
        private readonly DaprClient _daprClient;

        public GetUserPermissionsHandler(Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> user, EncryptionUtility utility
            , ILogger<GetUserPermissionsHandler> logger,DaprClient daprClient)
         =>
         (_user, _encryptionUtility,
            _logger, _daprClient) = (user, utility, logger,daprClient);

        public async Task<List<UserPermissionDto>> Handle(GetUserPermissionsRequest request, CancellationToken cancellationToken)
        {
            var result = new List<UserPermissionDto>();

            var appNames = new List<string> { "catalog", "filserver" };
            foreach (var appName in appNames)
            {
                var stateKey = $"{request.UserId}{appName}";

                _logger.LogInformation("Get State Key:");
                _logger.LogInformation(stateKey.ToLower());

                var appPermissions = await _daprClient.GetStateAsync<List<string>>(DAPR_STORE_NAME, stateKey.ToLower());
                result.Add(new UserPermissionDto
                {
                    AppName = appName,
                    PermissioKeys = appPermissions,
                });
            }

            return result;
        }
    }
}
