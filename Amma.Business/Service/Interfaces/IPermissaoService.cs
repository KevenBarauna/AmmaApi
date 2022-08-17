using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Business.Service.Interfaces
{
    public interface IPermissaoService
    {
        public Permissao GetById(int idPermissao);
        public List<Permissao> GetAll();
    }
}
