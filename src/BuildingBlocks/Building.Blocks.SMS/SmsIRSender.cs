using Building.Blocks.Core.Domain;
using Building.Blocks.SMS;
using Building.Blocks.SMS.Options;
using IPE.SmsIrRestful.TPL.NetCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BuildingBlocks.Email;

public class SmsIRSender : ISmsSender
{
    private readonly SmsOptions _config;
    private readonly ILogger<SmsIRSender> _logger;

    public SmsIRSender(IOptions<SmsOptions> config, ILogger<SmsIRSender> logger)
    {
        _config = config.Value;
        _logger = logger;
    }

    public Task SendAsync(SmsObject smsObject)
    {
        throw new NotImplementedException();
    }

    public async Task SendVerificationCodeFastWithTemplateIdAsync(SmsObjectForVerificationWithTemplate smsObject)
    {
        try
        {
            //install nuget package https://www.nuget.org/packages/SmsIrRestful/

            var token = new Token().GetToken(_config.SmsIrOption.UserApikey, _config.SmsIrOption.SecretKey);

            var ultraFastSend = new UltraFastSend()
            {
                Mobile = smsObject.ReciverNumber,
                TemplateId = _config.SmsIrUltraFastVerifticationOption.TemplateId,
                ParameterArray = new List<UltraFastParameters>()
    {
        new UltraFastParameters()
        {
            Parameter = GetMemberNameTools.GetMemberName((SmsObjectForVerificationWithTemplate c) => c.VerificationCode), ParameterValue = smsObject.VerificationCode
        }
    }.ToArray()

            };

            UltraFastSendRespone ultraFastSendRespone = new UltraFast().Send(token, ultraFastSend);

            if (ultraFastSendRespone.IsSuccessful)
            {

                _logger.LogInformation(
              "Sms Veriftication for iran sent. SmsProvider: \"SMS.IR\"," +
              " To: {To}, Subject: Veriftication Code For Login," +
              " Content: {Content}, From: SendVerificationCodeFastWithTemplateIdAsync," +
              " UserId:{UserId}",
              smsObject.ReciverNumber,
             smsObject,
              smsObject.UserId
          );

            }
            else
            {

            }
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
    }


}
