﻿using System;
using BdForProyectoControlVenta.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BdForProyectoControlVenta.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Pedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Correo")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Entregado")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<int>("SaldoFaltante")
                        .HasColumnType("int");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdVenta");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadEnB")
                        .HasColumnType("int");

                    b.Property<int>("CantidadMin")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.UnidadesVendidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadVendida")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<int>("PrecioUnitario")
                        .HasColumnType("int");

                    b.Property<string>("nProducto")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVenta");

                    b.ToTable("UnidadesVendidas");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("EstadoVacacional")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumeroDeDocumento")
                        .HasColumnType("int");

                    b.Property<string>("TipoDeDoc")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Ventas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cliente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CodTransaccion")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechadeventa")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Recaudo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Pedidos", b =>
                {
                    b.HasOne("BdForProyectoControlVenta.Models.Ventas", "Venta")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.UnidadesVendidas", b =>
                {
                    b.HasOne("BdForProyectoControlVenta.Models.Productos", "Producto")
                        .WithMany("UnidadesVendidas")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BdForProyectoControlVenta.Models.Ventas", "Venta")
                        .WithMany("UnidadesVendidas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Productos", b =>
                {
                    b.Navigation("UnidadesVendidas");
                });

            modelBuilder.Entity("BdForProyectoControlVenta.Models.Ventas", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("UnidadesVendidas");
                });
#pragma warning restore 612, 618
        }
    }
}
