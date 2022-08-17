using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Infrastructure.Interfaces
{
    public interface ICategoriaRepository
    {
        public List<Categoria> FindAll();
        public Categoria GetById(long id);

    }
}
