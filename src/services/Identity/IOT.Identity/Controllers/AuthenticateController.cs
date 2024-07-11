using Buildin.Blocks.Application.Security.Utility;
using IOT.Identity.Domain.Core;
using IOT.Identity.Infrastructure.Database.Context;
using IOT.Identity.Repositories;
using IOT.Identity.Service.CQRS.Permission.Queries.GetUserPermissions;
using IOT.Identity.Service.CQRS.Token.Commands.GetNewToken;
using IOT.Identity.Service.CQRS.User.Commands.RegisterNewUser;
using IOT.Identity.Service.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOT.Identity.Controllers
{
    public class AuthenticateController: BaseController
    {
        #region DI
        private readonly IdentityDbContext identityDbContext;
        private readonly EncryptionUtility encryptionUtility;
        private readonly IPermissionStateRepository permissionStateRepository;
        //private readonly IDistributedCache _cache;

        private readonly IMediator _mediator;

        public AuthenticateController(IdentityDbContext identityDbContext, EncryptionUtility encryptionUtility,
            IPermissionStateRepository permissionStateRepository, IMediator mediator)
        {
            this.identityDbContext = identityDbContext;
            this.encryptionUtility = encryptionUtility;
            this.permissionStateRepository = permissionStateRepository;
            this._mediator = mediator;
            //_cache = cache;
        }
        #endregion

        #region GetUserPermissionsState
        [HttpGet("{userName}")]
        public async Task<IActionResult> Ok([FromRoute] string userName)
        {
            var user = await identityDbContext.Users.SingleOrDefaultAsync(q => q.UserName == userName);
            var result = await permissionStateRepository.GetUserPermissionsState(user.Id.Value);
            return Ok(result);
        }
        #endregion

        #region login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(SaveUserPermissionsStateRequest loginRequest)
        {
            var result = await _mediator.Send(loginRequest);

            return Ok(result);

        }
        #endregion

        #region GetUserPermissions
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
        #endregion

        #region register

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromQuery]RegisterNewUserRequest registerNewUserRequest)
        {
            var result = await _mediator.Send(registerNewUserRequest);

            return Ok(result);
        }
        #endregion

        #region GenerateToken

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken(GetNewTokenRequestModel getNewTokenRequestModel)
        {
            var result = await _mediator.Send(getNewTokenRequestModel);

            return Ok(result);
        }
        #endregion
    }
}
