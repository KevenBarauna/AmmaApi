using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Constants;
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
            var todosUsuarios = _contexto.usuario.Include(x => x.Permissao).Include(x => x.Cargo);
            todosUsuarios.ToList().ForEach(x => x.Senha = Constant.SENHA_PADRAO);
            return todosUsuarios;
        }

        public Usuario Create(Usuario usuario)
        {
            _logger.LogInformation("### UsuarioRepository - Create");
            _contexto.usuario.Add(usuario);
            _contexto.SaveChanges();
            var usuarioRetornar = _contexto.usuario.Where(u => u.Id == usuario.Id).Include(x => x.Cargo).Include(x => x.Permissao).FirstOrDefault();
            usuarioRetornar.Senha = Constant.SENHA_PADRAO;
            return usuarioRetornar;
        }

        public Usuario Update(Usuario usuario)
        {
            _logger.LogInformation("### UsuarioRepository - Update");
            _contexto.usuario.Update(usuario);
            _contexto.SaveChanges();
            return _contexto.usuario.Where(u => u.Id == usuario.Id).Include(x => x.Cargo).Include(x => x.Permissao).FirstOrDefault();
        }

        public Usuario GetById(long id)
        {
            _logger.LogInformation($"### UsuarioRepository - GetById : ${id}");
            return _contexto.usuario.Where( u => u.Id == id).Include(x => x.Cargo).Include(x => x.Permissao).FirstOrDefault();
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