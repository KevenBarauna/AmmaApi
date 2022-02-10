using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;

namespace Amma.Business.Service.Interfaces
{
    public interface IUsuarioService
    {
        public List<Usuario> GetAllUsuarios();
        public Usuario CreateUsuario(Usuario usuario);
    }
}