using Estudos.Domain.Interfaces.Repositories;
using Estudos.Domain.Interfaces.Services;
using Estudos.Domain.Services;
using Estudos.Infra.Data.Context;
using Estudos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static Estudos.API.Controllers.EstudosController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Comando para configurar a connection string do banco
//builder.Services.AddDbContext<EstudosDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoEstudosSql")));
builder.Services.AddSqlServer<EstudosDbContext>(builder.Configuration.GetConnectionString("ProjetoEstudosSql"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Necessário adicionar ReferenceLoopHandling, devido o loop de referência que temos entre as classes relacionadas
// https://dotnetcoretutorials.com/2019/12/19/using-newtonsoft-json-in-net-core-3-projects/
// https://stackoverflow.com/questions/60197270/jsonexception-a-possible-object-cycle-was-detected-which-is-not-supported-this
builder.Services.AddMvc()
     .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

//Precisa injetar o BaseRepository, caso eu esteja usando o IBaseRepository diretamente em algum lugar (o que não deveria)
//builder.Services.AddScoped(typeof(BaseRepository<>));
builder.Services.AddScoped<IProductDbRepository, ProductDbRepository>();
builder.Services.AddScoped<IDescriptionRepository, DescriptionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDescriptionService, DescriptionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITagService, TagService>();

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
