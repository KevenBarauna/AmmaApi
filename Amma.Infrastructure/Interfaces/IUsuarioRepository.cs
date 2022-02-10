using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;

namespace Amma.Infrastructure.Interfaces
{
    public interface IUsuarioRepository
    {
        public IQueryable<Usuario> FindAll();
        public Usuario Create(Usuario usuario);
        public Usuario GetById(long id);
    }
}