using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Filmes.App.Dados
{
    public class FilmeCategoriaConfiguration : IEntityTypeConfiguration<FilmeCategoria>
    {
        public void Configure(EntityTypeBuilder<FilmeCategoria> builder)
        {
            builder.ToTable("film_category");

            builder.Property<int>("film_id").IsRequired();
            builder.Property<byte>("category_id").IsRequired();
            builder.Property<DateTime>("last_update")
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.HasKey("film_id", "category_id");

            builder
                .HasOne(fa => fa.Filme)
                .WithMany(f => f.Categorias)
                .HasForeignKey("film_id");

            builder
                .HasOne(fa => fa.Categoria)
                .WithMany(a => a.Filmes)
                .HasForeignKey("category_id");
        }
    }
}
