using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia;
using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Contract;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, ServiceDebugBehavior>(behavior =>
{
    var debugBehavior = new ServiceDebugBehavior
    {
        IncludeExceptionDetailInFaults = true
    };
    return debugBehavior;
});

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    {
        return RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter", _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromSeconds(15),
            QueueLimit = 0
        });
    });
    options.RejectionStatusCode = 429;
});

var app = builder.Build();

app.UseRateLimiter();

app.UseServiceModel(builder =>
{

    builder.AddService<TransferenciaTEDService>();
    builder.AddServiceEndpoint<TransferenciaTEDService, ITransferenciaTED>(new BasicHttpBinding(), "/TransferenciaTEDService.svc");


    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;
});





app.Run();