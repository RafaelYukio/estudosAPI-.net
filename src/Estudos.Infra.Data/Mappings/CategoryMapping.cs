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
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        // Para relacionamento de one-to-many com ProductToDb
        // One-to-many é criado uma coluna de ID para relacionar o lado hasOne da relação
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(category => category.Id);

            builder.Property(category => category.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(category => category.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();

            builder.HasMany(category => category.Products)
            .WithOne(product => product.Category);
        }
    }
}
