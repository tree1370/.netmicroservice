using Buildin.Blocks.Application.Security.Utility;
using FluentValidation;
using IOT.Identity.Domain.Core;
using IOT.Identity.Service.CQRS.Token.Commands.GetNewToken.Spec;
using MediatR;
using Microsoft.Extensions.Options;

namespace IOT.Identity.Service.CQRS.Token.Commands.GetNewToken
{
    public class GetNewTokenHandler : IRequestHandler<GetNewTokenRequestModel, GetNewTokenResponseModel>
    {
        private readonly Building.Blocks.Application.Persistence.IRepository<UserRefreshToken> _UserRefreshToken;
        private readonly EncryptionUtility _encryptionUtility;
        private readonly IMediator _mediator;
        private readonly Configs _configs;
        //    (_UserRefreshToken, _encryptionUtility, _mediator, _configs) = (user, encryptionUtility, mediator, configs);

        public GetNewTokenHandler(Building.Blocks.Application.Persistence.IRepository<UserRefreshToken> user, EncryptionUtility utility, IOptions<Configs> options)
         =>
         (_UserRefreshToken, _encryptionUtility, _configs) = (user, utility, options.Value);

        public Task<GetNewTokenResponseModel> Handle(GetNewTokenRequestModel request, CancellationToken cancellationToken)
        {
            return Handle(request, _UserRefreshToken, cancellationToken);
        }

        public async Task<GetNewTokenResponseModel> Handle(GetNewTokenRequestModel request, Building.Blocks.Application.Persistence.IRepository<UserRefreshToken> _UserRefreshToken, CancellationToken cancellationToken)
        {
            var currentRefreshToken = await _UserRefreshToken.FirstOrDefaultAsync(new RefreshTokenByGetCurrentToken(request.RefreshToken));

            if (currentRefreshToken == null) throw new Exception();

            var token = _encryptionUtility.GenerateToken(currentRefreshToken.UserId.Value);
            var refreshToken = "";

            //1-insert or update refresh token in db
            //2-send login sms

            //currentRefreshToken.RefreshToken = refreshToken;
            //currentRefreshToken.RefreshTokenTime = _configs.RefreshTokenTimeout;



            await _UserRefreshToken.UpdateAsync(currentRefreshToken, cancellationToken);

            //var addRefreshTokenNotification = new AddRefreshTokenNotification
            //{
            //    RefreshToken = refreshToken,
            //    RefreshTokenTimeOut = _configs.RefreshTokenTimeout, //read from configs
            //    UserId = currentRefreshToken.UserId,
            //};

            //await _mediator.Publish(addRefreshTokenNotification);


            var response = new GetNewTokenResponseModel
            {
                RefreshToken = "",
                Token = ""
            };


            return response;
        }
    }
}
