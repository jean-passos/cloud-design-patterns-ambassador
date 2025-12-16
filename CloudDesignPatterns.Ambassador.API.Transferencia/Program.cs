using CloudDesignPatterns.Ambassador.API.Transferencia.Business;
using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Transferencia",
        Description = "Operações de Transferencia Bancária"

    });

});



builder.Services.AddSingleton<ITransferenciaTED, TransferenciaTED>();
builder.Services.AddHttpClient<TransferenciaTED>("api-contacorrente", client =>
{
    client.BaseAddress = new Uri("http://localhost:3500/");
    client.DefaultRequestHeaders.Add("dapr-app-id", "api-contacorrente");
});

builder.Services.AddHttpClient("service-transferencia", client =>
{
    client.BaseAddress = new Uri("http://localhost:3500/v1.0/invoke/httpenpoint-service-transferencia/method/");
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
