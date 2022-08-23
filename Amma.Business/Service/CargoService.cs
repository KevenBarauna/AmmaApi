using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Business.Service
{
    public class CargoService : ICargoService
    {
        private readonly ILogger<CargoService> _logger;
        private readonly ICargoRepository _cargoRepository;


        public CargoService(ICargoRepository cargoRepository, ILogger<CargoService> logger)
        {
            _logger = logger;
            _cargoRepository = cargoRepository;
        }

        public Cargo GetById(int idCargo)
        {
            _logger.LogInformation($"### CargoService - GetById {idCargo}");
            return _cargoRepository.GetById(idCargo);
        }

        public List<Cargo> GetAll()
        {
            _logger.LogInformation($"### CargoService - GetAll");
            return _cargoRepository.FindAll();
        }
    }
}
