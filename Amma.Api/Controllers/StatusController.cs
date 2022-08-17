using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService _statusService;

        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }


        [HttpGet]
        [Route("BuscarTodosStatus")]
        public List<Status> GetAllStatus()
        {
            _logger.LogInformation($"### StatusController - GetAllStatus");
            return _statusService.GetAll();
        }


        [HttpGet]
        [Route("BuscarStatus")]
        public Status BuscarStatus([FromQuery] int idStatus)
        {
            _logger.LogInformation($"### StatusController - BuscarStatus: {idStatus}");
            return _statusService.GetById(idStatus);
        }
    }
}
