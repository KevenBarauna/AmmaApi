using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=localhost;Database=Amma;Trusted_Connection=True;");
        // }
    }
}