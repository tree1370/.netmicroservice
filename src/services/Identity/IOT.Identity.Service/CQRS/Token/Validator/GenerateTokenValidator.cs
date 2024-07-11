using Building.Blocks.Application.Common.Validation;
using Building.Blocks.Application.Persistence;
using FluentValidation;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.CQRS.Token.Commands.GetNewToken;
using IOT.Identity.Service.CQRS.Token.Commands.GetNewToken.Spec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Identity.Service.CQRS.Token.Validator
{
    public class GenerateTokenValidator : CustomValidator<GetNewTokenRequestModel>
    {
        public GenerateTokenValidator(IReadRepository<UserRefreshToken> userRefreshToken)
        {
            RuleFor(c => c.RefreshToken)
                .NotEmpty()
                .MaximumLength(20)
                .MustAsync(async (token, ct) => await userRefreshToken.GetBySpecAsync(new RefreshTokenByGetCurrentToken(token)) is null)
                    .WithMessage((_, token) => $"refreshtoken '{token}' already Exists.");



        }
    }
}
