using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Data.Repository
{
    public class StatusRepository : IStatusRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<StatusRepository> _logger;

        public StatusRepository(Contexto contexto, ILogger<StatusRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }
        public List<Status> FindAll()
        {
            _logger.LogInformation("### StatusRepository - FindAll");
            return _contexto.status.ToList();
        }

        public Status GetById(long id)
        {
            _logger.LogInformation($"### StatusRepository - GetById : ${id}");
            return _contexto.status.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
