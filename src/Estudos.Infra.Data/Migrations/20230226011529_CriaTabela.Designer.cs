﻿// <auto-generated />
using System;
using Estudos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Estudos.Infra.Data.Migrations
{
    [DbContext(typeof(EstudosDbContext))]
    [Migration("20230226011529_CriaTabela")]
    partial class CriaTabela
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Estudos.Domain.Entities.ProductsToDb", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Qtd")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
