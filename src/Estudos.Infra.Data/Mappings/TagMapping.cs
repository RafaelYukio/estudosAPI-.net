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
    public class TagMapping : IEntityTypeConfiguration<Tag>
    {
        // Para relacionamento de many-to-many com ProductToDb
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(tag => tag.Id);

            builder.Property(tag => tag.CreatedAt)
            .HasColumnType("datetime")
            .IsRequired();

            builder.Property(product => product.Name)
            .HasColumnType("varchar(255)")
            .IsRequired();

            builder.HasMany(tag => tag.Products)
            .WithMany(product => product.Tags);
        }
    }
}
