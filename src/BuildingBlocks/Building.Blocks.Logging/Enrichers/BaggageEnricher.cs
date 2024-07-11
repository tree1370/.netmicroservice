using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;

namespace Building.Blocks.Logging;

public class BaggageEnricher : ILogEventEnricher
{

    private readonly IHttpContextAccessor contextAccessor;

    public BaggageEnricher() : this(new HttpContextAccessor())
    {
    }

    public BaggageEnricher(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (Activity.Current == null)
            return;

        string ip = $"({contextAccessor.HttpContext?.Connection.RemoteIpAddress.ToString() ?? "unknown"})";
        logEvent.AddPropertyIfAbsent(new LogEventProperty("IP", new ScalarValue(ip)));

        foreach (var (key, value) in Activity.Current.Baggage)
        {
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(key, value));

        }
    }
}
