using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia;
using CloudDesignPatterns.Ambassador.Service.ServicoTransferencia.Contract;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;

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

var app = builder.Build();

app.UseServiceModel(builder => { 

    builder.AddService<TransferenciaTEDService>();
    builder.AddServiceEndpoint<TransferenciaTEDService, ITransferenciaTED>(new BasicHttpBinding(), "/TransferenciaTEDService.svc");


    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;
});

app.Run();