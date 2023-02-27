using Estudos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Estudos.API.Controllers.EstudosController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Comando para configurar a connection string do banco
builder.Services.AddDbContext<EstudosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoEstudosSql")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Teste do Init() dos Products (inicializando produtos salvos no appsettings)
    var configuration = app.Configuration;
    ProductRepository.Init(configuration);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
