using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Context
{
    public class EstudosDbContext : DbContext
    {
        // Consigo configurar a string de conexão aqui, mas o ideal é em appsettings e nas configs
        // no Program.cs é preciso adicionar builder.Services.AddDbContext (EntityFrameworkCore.SqlServer) e tb precisa do EntityFrameworkCore.Design para migrations
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=localhost;Database=ProjetoEstudos;User Id=sa;Password=@Sql2022;");

        // Precisa do construtor passando as options, se não ocorre erro (é aí que são passados os options como a connection string?)
        public EstudosDbContext(DbContextOptions<EstudosDbContext> options) : base(options) { }

        // OnModelCreating faz as configs. dos mappings (IEntityTypeConfiguration) serem executadas
        // Conceito Fluent API/Mapping
        // https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties
        // https://balta.io/blog/csharp-fluent-apis
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<ProductToDb> ProductsToDb { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
