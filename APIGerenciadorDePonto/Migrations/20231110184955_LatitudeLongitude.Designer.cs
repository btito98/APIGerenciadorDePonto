﻿// <auto-generated />
using System;
using APIGerenciadorDePonto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIGerenciadorDePonto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231110184955_LatitudeLongitude")]
    partial class LatitudeLongitude
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APIGerenciadorDePonto.Model.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("razaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("APIGerenciadorDePonto.Model.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FKEmpresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FKPerfil")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cargaHoraria")
                        .HasColumnType("int");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FKEmpresa");

                    b.HasIndex("FKPerfil");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("APIGerenciadorDePonto.Model.Perfil", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("perfils");
                });

            modelBuilder.Entity("APIGerenciadorDePonto.Model.RegistroPonto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FKFuncionario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Logintude")
                        .HasColumnType("float");

                    b.Property<DateTime>("dataHoraEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataHoraSaida")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RegistrosPonto");
                });

            modelBuilder.Entity("APIGerenciadorDePonto.Model.Funcionario", b =>
                {
                    b.HasOne("APIGerenciadorDePonto.Model.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("FKEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIGerenciadorDePonto.Model.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("FKPerfil")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("APIGerenciadorDePonto.Model.Empresa", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
