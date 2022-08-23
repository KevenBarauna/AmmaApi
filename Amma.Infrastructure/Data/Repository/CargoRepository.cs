using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Data.Repository
{
    public class CargoRepository : ICargoRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<CargoRepository> _logger;

        public CargoRepository(Contexto contexto, ILogger<CargoRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }

        public List<Cargo> FindAll()
        {
            _logger.LogInformation("### CargoRepository - FindAll");
            return _contexto.cargo.ToList();
        }

        public Cargo GetById(long id)
        {
            _logger.LogInformation($"### CargoRepository - GetById : ${id}");
            return _contexto.cargo.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
