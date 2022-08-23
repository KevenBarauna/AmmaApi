using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Infrastructure.Interfaces
{
    public interface ICargoRepository
    {
        public List<Cargo> FindAll();
        public Cargo GetById(long id);
    }
}
