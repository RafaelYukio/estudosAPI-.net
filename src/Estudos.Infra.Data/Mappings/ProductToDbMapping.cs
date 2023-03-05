using Estudos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos.Infra.Data.Mappings
{
    public class ProductToDbMapping : IEntityTypeConfiguration<ProductToDb>
    {
        // Guia para relacionamentos de entidades:
        // https://learn.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#required-and-optional-relationships

        // Possível usar Data Annotations na entidade para especificar uma prop (cria coluna na tabela) para FK
        // https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
        // Diferença entre usar Data Annotations e Fluent API (o melhor é usar Fluent API mesmo, como aqui):
        // https://pt.stackoverflow.com/questions/168377/qual-a-diferença-entre-data-annotations-e-fluent-api

        // Apenas fazendo referência entre classes no mapping, não cria coluna para FKs
        public void Configure(EntityTypeBuilder<ProductToDb> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(product => product.Code)
            .HasColumnType("int")
            .IsRequired();

            builder.Property(product => product.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();

            builder.Property(product => product.Qtd)
            .HasColumnName("Quantity")
            .HasColumnType("int")
            .IsRequired();

            builder.HasOne(product => product.Description)
            .WithOne(description => description.Product)
            .HasForeignKey<Description>(description => description.Id);

            builder.HasOne(product => product.Category)
            .WithMany(category => category.Products);

            builder.HasMany(product => product.Tags)
            .WithMany(tag => tag.Products);
        }
    }
}
