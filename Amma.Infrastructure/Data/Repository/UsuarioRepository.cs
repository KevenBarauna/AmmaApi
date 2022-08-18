using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Amma.Infrastructure.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(Contexto contexto, ILogger<UsuarioRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }
        public IQueryable<Usuario> FindAll()
        {
            _logger.LogInformation("### UsuarioRepository - FindAll");
            return _contexto.usuario;
        }

        public Usuario Create(Usuario usuario)
        {
            _logger.LogInformation("### UsuarioRepository - Create");
            _contexto.usuario.Add(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario Update(Usuario usuario)
        {
            _logger.LogInformation("### UsuarioRepository - Update");
            _contexto.usuario.Update(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

        public Usuario GetById(long id)
        {
            _logger.LogInformation($"### UsuarioRepository - GetById : ${id}");
            return _contexto.usuario.Where( u => u.Id == id).FirstOrDefault();
        }

        public Usuario GetByNomeSenha(string usuarioNome, string usuarioSenha)
        {
            _logger.LogInformation($"### UsuarioRepository - GetByNomeSenha");
            return _contexto.usuario.Where(u => u.Nome == usuarioNome && u.Senha == usuarioSenha).FirstOrDefault();
        }

        public Usuario Delete(Usuario usuario)
        {
            _logger.LogInformation($"### UsuarioRepository - Delete : ${usuario?.Id}");
            _contexto.usuario.Remove(usuario);
            _contexto.SaveChanges();
            return usuario;
        }

    }
}