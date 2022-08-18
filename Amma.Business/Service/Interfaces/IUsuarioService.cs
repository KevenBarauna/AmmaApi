using System.Collections.Generic;
using Amma.Core.Domain.Entities;

namespace Amma.Business.Service.Interfaces
{
    public interface IUsuarioService
    {
        public List<Usuario> GetAllUsuarios();
        public Usuario CreateUsuario(Usuario usuario);
        public Usuario EditarUsuario(Usuario usuario);
        public Usuario GetUsuario(int idUsuario);
        public Usuario DeletarUsuario(int idUsuario);
        public Usuario GetUsuarioByLogin(string usuarioNome, string usuarioSenha);
    }
}