using Amma.Business.Service;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CargoController : Controller
    {

        private readonly ILogger<CargoController> _logger;
        private readonly ICargoService _cargoService;

        public CargoController(ILogger<CargoController> logger, ICargoService cargoService)
        {
            _logger = logger;
            _cargoService = cargoService;
        }


        [HttpGet]
        [Route("BuscarTodosCargos")]
        [AllowAnonymous]
        public List<Cargo> GetAllStatus()
        {
            _logger.LogInformation($"### CargoController - GetAllStatus");
            return _cargoService.GetAll();
        }


        [HttpGet]
        [Route("BuscarCargo")]
        [AllowAnonymous]
        public Cargo BuscarStatus([FromQuery] int idStatus)
        {
            _logger.LogInformation($"### CargoController - BuscarCargo: {idStatus}");
            return _cargoService.GetById(idStatus);
        }

    }
}
