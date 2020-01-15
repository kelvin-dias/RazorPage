﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Context;

namespace Persistencia.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20200114131926_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.Entidades.IteracaoOcorrencia", b =>
                {
                    b.Property<long?>("IteracaoOcorrenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Assinatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataHoraIteracao")
                        .HasColumnType("datetime2");

                    b.Property<long?>("OcorrenciaId")
                        .HasColumnType("bigint");

                    b.Property<string>("TextoIteracao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IteracaoOcorrenciaId");

                    b.HasIndex("OcorrenciaId");

                    b.ToTable("ITERACOES_OCORRENCIAS");
                });

            modelBuilder.Entity("Modelo.Entidades.Ocorrencia", b =>
                {
                    b.Property<long?>("OcorrenciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CriticidadeOcorrencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<long?>("NumeroOcorrencia")
                        .HasColumnType("bigint");

                    b.Property<string>("Solucao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatusOcorrencia")
                        .HasColumnType("bit");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OcorrenciaId");

                    b.ToTable("OCORRENCIAS");
                });

            modelBuilder.Entity("Modelo.Entidades.IteracaoOcorrencia", b =>
                {
                    b.HasOne("Modelo.Entidades.Ocorrencia", "Ocorrencia")
                        .WithMany("Iteracoes")
                        .HasForeignKey("OcorrenciaId");
                });
#pragma warning restore 612, 618
        }
    }
}