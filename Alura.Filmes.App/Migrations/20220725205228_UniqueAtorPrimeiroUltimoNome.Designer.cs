﻿// <auto-generated />
using System;
using Alura.Filmes.App.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alura.Filmes.App.Migrations
{
    [DbContext(typeof(AluraFilmesContexto))]
    [Migration("20220725205228_UniqueAtorPrimeiroUltimoNome")]
    partial class UniqueAtorPrimeiroUltimoNome
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("actor_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PrimeiroNome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("first_name");

                    b.Property<string>("UltimoNome")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.HasAlternateKey("PrimeiroNome", "UltimoNome");

                    b.HasIndex("UltimoNome")
                        .HasDatabaseName("idx_actor_last_name");

                    b.ToTable("actor", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Categoria", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("category_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("film_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AnoLancamento")
                        .HasColumnType("varchar(4)")
                        .HasColumnName("release_year");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<short>("Duracao")
                        .HasColumnType("smallint")
                        .HasColumnName("length");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.Property<byte>("language_id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<byte?>("original_language_id")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("language_id");

                    b.HasIndex("original_language_id");

                    b.ToTable("film", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.FilmeAtor", b =>
                {
                    b.Property<int>("film_id")
                        .HasColumnType("int");

                    b.Property<int>("actor_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("film_id", "actor_id");

                    b.HasIndex("actor_id");

                    b.ToTable("film_actor", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.FilmeCategoria", b =>
                {
                    b.Property<int>("film_id")
                        .HasColumnType("int");

                    b.Property<byte>("category_id")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("film_id", "category_id");

                    b.HasIndex("category_id");

                    b.ToTable("film_category", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Idioma", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint")
                        .HasColumnName("language_id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("char(20)")
                        .HasColumnName("name");

                    b.Property<DateTime>("last_update")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("Id");

                    b.ToTable("language", (string)null);
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Filme", b =>
                {
                    b.HasOne("Alura.Filmes.App.Negocio.Idioma", "IdiomaFalado")
                        .WithMany("FilmesFalados")
                        .HasForeignKey("language_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.Filmes.App.Negocio.Idioma", "IdiomaOriginal")
                        .WithMany("FilmesOriginais")
                        .HasForeignKey("original_language_id");

                    b.Navigation("IdiomaFalado");

                    b.Navigation("IdiomaOriginal");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.FilmeAtor", b =>
                {
                    b.HasOne("Alura.Filmes.App.Negocio.Ator", "Ator")
                        .WithMany("Filmografia")
                        .HasForeignKey("actor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.Filmes.App.Negocio.Filme", "Filme")
                        .WithMany("Atores")
                        .HasForeignKey("film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ator");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.FilmeCategoria", b =>
                {
                    b.HasOne("Alura.Filmes.App.Negocio.Categoria", "Categoria")
                        .WithMany("Filmes")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alura.Filmes.App.Negocio.Filme", "Filme")
                        .WithMany("Categorias")
                        .HasForeignKey("film_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Ator", b =>
                {
                    b.Navigation("Filmografia");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Categoria", b =>
                {
                    b.Navigation("Filmes");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Filme", b =>
                {
                    b.Navigation("Atores");

                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("Alura.Filmes.App.Negocio.Idioma", b =>
                {
                    b.Navigation("FilmesFalados");

                    b.Navigation("FilmesOriginais");
                });
#pragma warning restore 612, 618
        }
    }
}
