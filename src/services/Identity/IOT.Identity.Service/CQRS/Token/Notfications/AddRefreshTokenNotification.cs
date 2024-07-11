//using Dapr.Client;
//using IOT.Identity.Service.User;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IOT.Identity.Service.Token.CQRS.Notfications
//{
//    internal class AddRefreshTokenNotification : INotification
//    {
//        public string RefreshToken { get; set; }
//        public UserId UserId { get; set; }
//        public int RefreshTokenTimeOut { get; set; }
//    }

//    public class AddRefreshTokenNotificationHandler : INotificationHandler<AddRefreshTokenNotification>
//    {
//        private const string DAPR_STORE_NAME = "statestore";
//        private readonly DaprClient _daprClient;
//        private readonly ILogger _logger;
//        public AddRefreshTokenNotificationHandler(DaprClient daprClient, ILogger logger) => (_daprClient, _logger) = (daprClient, logger);
     
//        public async Task Handle(AddRefreshTokenNotification notification, CancellationToken cancellationToken)
//        {
//            var stateKey = $"{userId}{appName}";

//            _logger.LogInformation("Get State Key:");
//            _logger.LogInformation(stateKey.ToLower());

//            var appPermissions = await _daprClient.GetStateAsync<List<string>>(DAPR_STORE_NAME, stateKey.ToLower());
//            if(appPermissions.Any())
//            {

//            }

//        }
//    }
//}
