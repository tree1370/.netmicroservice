using Buildin.Blocks.Application.Security.Utility;
using Building.Blocks.Core.EFCore;
using Google.Api;
using IOT.Identity;
using IOT.Identity.Configurations;
using IOT.Identity.GrpcServices;
using IOT.Identity.Repositories;
using IOT.Identity.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using Building.Blocks.Logging;
using Serilog.Context;
using Serilog.Events;
using Building.Blocks.Core.Extensions;


//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    ApplicationName = typeof(Program).Assembly.FullName,
//    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
//    WebRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
//    Args = args
//});

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOptions();
builder.Services.Configure<Configs>(builder.Configuration.GetSection("Configs"));

var daprHttpPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3605";
var daprGrpcPort = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "60005";
builder.Services.AddDaprClient(builder => builder
    .UseHttpEndpoint($"http://localhost:{daprHttpPort}")
    .UseGrpcEndpoint($"http://localhost:{daprGrpcPort}"));


builder.Services.AddSingleton<EncryptionUtility>();
builder.Services.AddSingleton<GetCurrentUser>();

builder.Services.AddScoped<IPermissionStateRepository, PermissionStateRepository>();

builder.Services.AddControllers().AddDapr();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddRepositories();
//builder.Services.AddUnitOfWork();
builder.Services.AddInfraUtility();

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddBlockCore();

builder.Services.AddControllers().AddDapr();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDI(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.AddCustomSerilog();



var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapSubscribeHandler();
app.MapControllers();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGrpcService<PermissionService>();
//});

app.Use(async (ctx, next) => {
    using (LogContext.PushProperty("IPAddress", ctx.Connection.RemoteIpAddress))
    {
        await next(ctx);
    }
});

app.UseSerilogRequestLogging(options =>
{

    // Attach additional properties to the request completion event
    options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
    {
        diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
        diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
        diagnosticContext.Set("RemoteIpAddress", httpContext.Connection.RemoteIpAddress);
    };
});

//app.Run();
app.Run("http://localhost:6005");
