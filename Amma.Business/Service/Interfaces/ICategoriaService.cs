using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Business.Service.Interfaces
{
    public interface ICategoriaService
    {
        public Categoria GetById(int idPermissao);
        public List<Categoria> GetAll();
    }
}
