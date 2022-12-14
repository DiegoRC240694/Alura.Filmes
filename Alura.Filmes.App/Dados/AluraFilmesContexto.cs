using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App.Dados
{
    public class AluraFilmesContexto : DbContext
    {
        public DbSet<Ator>? Atores { get; set; }
        public DbSet<Filme>? Filmes { get; set; }
        public DbSet<FilmeAtor>? Elenco { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }   
        public DbSet<FilmeCategoria>? Generos { get; set; }
        public DbSet<Idioma>? Idiomas { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AluraFilmesTST;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtorConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeAtorConfiguration());

            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());

            modelBuilder.ApplyConfiguration(new FilmeCategoriaConfiguration());

            modelBuilder.ApplyConfiguration(new IdiomaConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());

            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
        }
    }
}
