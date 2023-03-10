// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Medii_de_prodramare.Data;

#nullable disable

namespace Proiect_Medii_de_prodramare.Migrations
{
    [DbContext(typeof(Proiect_Medii_de_prodramareContext))]
    partial class Proiect_Medii_de_prodramareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlatformID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PlatformID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.GameCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("GameID");

                    b.ToTable("GameCategory");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Platform", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Shopping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("GameID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("GameID");

                    b.ToTable("Shopping");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Game", b =>
                {
                    b.HasOne("Proiect_Medii_de_prodramare.Models.Platform", "Platform")
                        .WithMany("Games")
                        .HasForeignKey("PlatformID");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.GameCategory", b =>
                {
                    b.HasOne("Proiect_Medii_de_prodramare.Models.Category", "Category")
                        .WithMany("GameCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Medii_de_prodramare.Models.Game", "Game")
                        .WithMany("GameCategories")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Shopping", b =>
                {
                    b.HasOne("Proiect_Medii_de_prodramare.Models.Customer", "Customer")
                        .WithMany("Shoppings")
                        .HasForeignKey("CustomerID");

                    b.HasOne("Proiect_Medii_de_prodramare.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameID");

                    b.Navigation("Customer");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Category", b =>
                {
                    b.Navigation("GameCategories");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Customer", b =>
                {
                    b.Navigation("Shoppings");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Game", b =>
                {
                    b.Navigation("GameCategories");
                });

            modelBuilder.Entity("Proiect_Medii_de_prodramare.Models.Platform", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
