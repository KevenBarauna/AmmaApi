using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Infrastructure.Interfaces
{
    public interface ICargoService
    {
        public Cargo GetById(int idCargo);
        public List<Cargo> GetAll();
    }
}
