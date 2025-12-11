using CloudDesignPatterns.Ambassador.API.Transferencia.Business;
using CloudDesignPatterns.Ambassador.API.Transferencia.Business.Interface;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
