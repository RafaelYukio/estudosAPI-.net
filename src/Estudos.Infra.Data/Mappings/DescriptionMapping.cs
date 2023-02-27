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
    public class DescriptionMapping : IEntityTypeConfiguration<Description>
    {
        // Para relacionamento de one-to-one com ProductToDb
        public void Configure(EntityTypeBuilder<Description> builder)
        {
            builder.ToTable("Descriptions");

            builder.HasKey(description => description.Id);

            builder.Property(description => description.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(product => product.Details)
            .HasColumnType("varchar(255)")
            .IsRequired();

            builder.HasOne(description => description.Product)
            .WithOne(product => product.Description)
            .HasForeignKey<ProductToDb>(product => product.Id);
        }
    }
}
