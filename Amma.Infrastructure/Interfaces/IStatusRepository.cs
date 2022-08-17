using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Infrastructure.Interfaces
{
    public interface IStatusRepository
    {
        public List<Status> FindAll();

        public Status GetById(long id);
    }
}
