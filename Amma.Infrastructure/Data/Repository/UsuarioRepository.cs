using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amma.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public IQueryable<Usuario> FindAll()
        {
            // _logger.LogInformation("#### UsuarioRepository - FindAll ####");
            return _contexto.usuario;
        }

        public Usuario Create(Usuario usuario)
        {
            // _logger.LogInformation("#### UsuarioRepository - Create ####");
            _contexto.usuario.Add(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario GetById(long id)
        {
            return _contexto.usuario.Where( u => u.Id == id).FirstOrDefault();
        }

    }
}