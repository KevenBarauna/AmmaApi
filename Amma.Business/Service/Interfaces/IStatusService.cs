using Amma.Core.Domain.Entities;
using System.Collections.Generic;

namespace Amma.Business.Service.Interfaces
{
    public interface IStatusService
    {
        public Status GetById(int idStatus);
        public List<Status> GetAll();
    }
}
