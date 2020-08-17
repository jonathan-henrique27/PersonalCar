﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalCar.Data;

namespace PersonalCar.Migrations
{
    [DbContext(typeof(PersonalCarContext))]
    [Migration("20200812164759_remocao-cliente-id")]
    partial class remocaoclienteid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalCar.Models.Domains.CentroDeCusto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UnidadeDeNegocioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeDeNegocioId");

                    b.ToTable("CentroDeCusto");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.HoraParada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("HoraParada");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Motorista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CNH")
                        .HasColumnType("int");

                    b.Property<DateTime>("CnhVenc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Nascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motorista");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Passageiro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("Passageiro");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Solicitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Telecom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadeDeNegocioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnidadeDeNegocioId");

                    b.ToTable("Solicitante");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.UnidadeDeNegocio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Ibge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("UnidadeDeNegocio");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Viagem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalKM")
                        .HasColumnType("float");

                    b.Property<double>("ValorPorKm")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("float");

                    b.Property<int?>("VoucherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VoucherId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CentroDeCustoId")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("ControleDeTaxiamento")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicial")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime2");

                    b.Property<double>("KmFinal")
                        .HasColumnType("float");

                    b.Property<double>("KmInicial")
                        .HasColumnType("float");

                    b.Property<int?>("MotoristaId")
                        .HasColumnType("int");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SolicitanteId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UnidadeId")
                        .HasColumnType("int");

                    b.Property<double>("ValorEstacionamento")
                        .HasColumnType("float");

                    b.Property<double>("ValorPedagio")
                        .HasColumnType("float");

                    b.Property<double>("ValorTotalDaViagem")
                        .HasColumnType("float");

                    b.Property<int?>("VeiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CentroDeCustoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MotoristaId");

                    b.HasIndex("SolicitanteId");

                    b.HasIndex("UnidadeId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.CentroDeCusto", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.UnidadeDeNegocio", null)
                        .WithMany("CentroDeCustos")
                        .HasForeignKey("UnidadeDeNegocioId");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.HoraParada", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.Voucher", "Voucher")
                        .WithMany("HorasParado")
                        .HasForeignKey("VoucherId");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Passageiro", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.Voucher", "Voucher")
                        .WithMany("Passageiros")
                        .HasForeignKey("VoucherId");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Solicitante", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.UnidadeDeNegocio", "UnidadeDeNegocio")
                        .WithMany("Solicitantes")
                        .HasForeignKey("UnidadeDeNegocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.UnidadeDeNegocio", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.Cliente", "Cliente")
                        .WithMany("UnidadeDeNegocios")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Viagem", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.Voucher", "Voucher")
                        .WithMany("Viagens")
                        .HasForeignKey("VoucherId");
                });

            modelBuilder.Entity("PersonalCar.Models.Domains.Voucher", b =>
                {
                    b.HasOne("PersonalCar.Models.Domains.CentroDeCusto", "CentroDeCusto")
                        .WithMany("Vouchers")
                        .HasForeignKey("CentroDeCustoId");

                    b.HasOne("PersonalCar.Models.Domains.Cliente", "Cliente")
                        .WithMany("Vouchers")
                        .HasForeignKey("ClienteId");

                    b.HasOne("PersonalCar.Models.Domains.Motorista", "Motorista")
                        .WithMany("Vouchers")
                        .HasForeignKey("MotoristaId");

                    b.HasOne("PersonalCar.Models.Domains.Solicitante", null)
                        .WithMany("Vouchers")
                        .HasForeignKey("SolicitanteId");

                    b.HasOne("PersonalCar.Models.Domains.UnidadeDeNegocio", "Unidade")
                        .WithMany("Vouchers")
                        .HasForeignKey("UnidadeId");

                    b.HasOne("PersonalCar.Models.Domains.Veiculo", "Veiculo")
                        .WithMany("Vouchers")
                        .HasForeignKey("VeiculoId");
                });
#pragma warning restore 612, 618
        }
    }
}
