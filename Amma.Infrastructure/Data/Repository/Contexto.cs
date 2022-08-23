using Amma.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Amma.Infrastructure.Data.Repository
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> usuario {get; set;}
        public DbSet<Permissao> permissao {get; set;}
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Status> status { get; set; }
        public DbSet<Sugestao> sugestao { get; set; }
        public DbSet<Cargo> cargo { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}