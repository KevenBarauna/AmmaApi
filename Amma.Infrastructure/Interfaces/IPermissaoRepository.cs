using Amma.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Interfaces
{
    public interface IPermissaoRepository
    {
        public List<Permissao> FindAll();
        public Permissao GetById(long id);
    }
}
