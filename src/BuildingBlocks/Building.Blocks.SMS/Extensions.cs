using Building.Blocks.Core;
using Building.Blocks.Core.Web.Extenions;
using Building.Blocks.SMS.Options;
using BuildingBlocks.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Building.Blocks.SMS;

public static class Extensions
{
    public static IServiceCollection AddSmsService(
        this IServiceCollection services,
        IConfiguration configuration,
        SmsProvider provider = SmsProvider.SMSIR,
        Action<SmsOptions>? configureOptions = null
    )
    {
        var config = configuration.BindOptions<SmsOptions>(nameof(SmsOptions));
        configureOptions?.Invoke(config ?? new SmsOptions());

        if (provider == SmsProvider.SMSIR)
        {
            services.AddSingleton<ISmsSender, SmsIRSender>();
        }
        else
        {
            services.AddSingleton<ISmsSender, SmsIRSender>();
        }

        if (configureOptions is { })
        {
            services.Configure(nameof(SmsOptions), configureOptions);
        }
        else
        {
            services
              .AddOptions<SmsOptions>()
              .Bind(configuration.GetSection(nameof(SmsOptions)))
              .ValidateDataAnnotations();
        }

        return services;
    }
}
