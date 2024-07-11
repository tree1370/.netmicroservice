using Building.Blocks.Core.Domain;
using Building.Blocks.Core.Exception.Types;
using IOT.Identity.Service.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.CQRS.User.Commands.RegisterNewUser.Spec;
using Buildin.Blocks.Application.Security.Utility;

namespace IOT.Identity.Service.CQRS.User.Commands.RegisterNewUser
{
    public class RegisterNewUserHandler : IRequestHandler<RegisterNewUserRequest, RegisterNewUserResponse>
    {
        private readonly Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> _user;
        private readonly EncryptionUtility _encryptionUtility;
        private readonly IMediator _mediator;

        public RegisterNewUserHandler(Building.Blocks.Application.Persistence.IRepository<Domain.Core.User> user, EncryptionUtility utility)
         =>
         (_user, _encryptionUtility) = (user, utility);


        public async Task<RegisterNewUserResponse> Handle(RegisterNewUserRequest request, CancellationToken cancellationToken)
        {
            var existsEmail = await _user.AnyAsync(new GetUserByUserNameForRegister(request.Email));
            if (existsEmail) throw new BadRequestException($"user name '{request.Email}' is exist.");

            var salt = Guid.NewGuid().ToString();
            var hashPassword = _encryptionUtility.GenerateSHA256(request.Password, salt);

            var newUser = Domain.Core.User.Of(request.Email, request.Email, request.FirstName, request.LastName, request.CountryCode, request.PhoneNumber, hashPassword,
                salt, DateTime.Now, DateTime.Now, true, request.BirthDate, request.Gender, 0, false, DateTime.Now, request.LogInType,null);

            await _user.AddAsync(newUser);

            return new RegisterNewUserResponse { Id = newUser.Id.Value };
        }


    }
}
