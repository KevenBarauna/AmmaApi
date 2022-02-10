using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amma.Business.Service
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository ;

        public UsuarioService(IUsuarioRepository usuarioRepository )
        {
            _usuarioRepository  = usuarioRepository ;
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            // _logger.LogInformation("#### UsuarioService - CreateUsuario ####");
            return _usuarioRepository.Create(usuario);
        }

        public List<Usuario> GetAllUsuarios()
        {
            // _logger.LogInformation("#### UsuarioService - GetAllUsuarios ####");

            var usuarios = _usuarioRepository.FindAll();

            // _logger.LogInformation($"#### UsuarioService - GetAllUsuarios - Find: {usuarios?.Count} Usuários ####");

            return usuarios.Include(x => x.permissao).ToList();
        }
    }
}