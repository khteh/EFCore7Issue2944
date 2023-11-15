﻿// <auto-generated />
using EfCoreNullBug;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCoreNullBug.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20231115141203_AddItemId")]
    partial class AddItemId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCoreNullBug.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EfCoreNullBug.Order", b =>
                {
                    b.OwnsOne("EfCoreNullBug.OrderItem", "Item", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("integer");

                            b1.Property<int>("ItemId")
                                .HasColumnType("integer");

                            b1.Property<string>("ItemName")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Item")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
