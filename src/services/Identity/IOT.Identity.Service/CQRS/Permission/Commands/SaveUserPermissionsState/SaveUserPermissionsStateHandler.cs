using Buildin.Blocks.Application.Security.Utility;
using Building.Blocks.Application.Persistence;
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
    public class SaveUserPermissionsStateHandler : IRequestHandler<SaveUserPermissionsStateRequest, bool>
    {

        private readonly Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> _user;
        private readonly EncryptionUtility _encryptionUtility;
        private readonly IMediator _mediator;
        private readonly ILogger<SaveUserPermissionsStateHandler> _logger;
        private const string DAPR_STORE_NAME = "statestore";
        private readonly DaprClient _daprClient;

        public SaveUserPermissionsStateHandler(Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> user, EncryptionUtility utility
            , ILogger<SaveUserPermissionsStateHandler> logger,DaprClient daprClient)
         =>
         (_user, _encryptionUtility,
            _logger, _daprClient) = (user, utility, logger,daprClient);

    

        public async Task<bool> Handle(SaveUserPermissionsStateRequest request, CancellationToken cancellationToken)
        {
            var userPermission = GetUserPermissions(request.UserId.Value); //from db

            foreach (var item in userPermission)
            {
                var stateKey = (request.UserId.Value.ToString() + item.AppName).ToLower();
                _logger.LogInformation("Write State Key:");
                _logger.LogInformation(stateKey);
                await _daprClient.SaveStateAsync<List<string>>(DAPR_STORE_NAME, stateKey, item.PermissioKeys);
            }

            return true;
        }

        private List<UserPermissionDto> GetUserPermissions(Guid userId)
        {
            var userPermissions = new List<UserPermissionDto>();
            userPermissions.Add(new UserPermissionDto
            {
                AppName = "Catalog",
                PermissioKeys = { "Category_Add", "Category_Delete" }, //, "Category_Get_All" },
            });

            userPermissions.Add(new UserPermissionDto
            {
                AppName = "FileServer",
                PermissioKeys = { "FileManager_Upload", "FileManager_Download" },
            });

            return userPermissions;

        }
    }
}
