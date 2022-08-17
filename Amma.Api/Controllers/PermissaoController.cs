using Amma.Api.Models.DTO;
using Amma.Api.ViewModels;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissaoController : Controller
    {

        private readonly ILogger<PermissaoController> _logger;
        private readonly IPermissaoService _permissaoService;
        private readonly IMapper _mapper;

        public PermissaoController(ILogger<PermissaoController> logger, IMapper mapper, IPermissaoService permissaoService)
        {
            _logger = logger;
            _mapper = mapper;
            _permissaoService = permissaoService;
        }


        [HttpGet]
        [Route("BuscarTodasPermissoes")]
        public List<Permissao> GetAllPermissoes()
        {
            _logger.LogInformation($"### PermissaoController - GetAllPermissoes");
            return _permissaoService.GetAll();
        }


        [HttpGet]
        [Route("BuscarPermissao")]
        public Permissao BuscarPermissao([FromQuery] int idPermissao)
        {
            _logger.LogInformation($"### PermissaoController - BuscarPermissao: {idPermissao}");
            return _permissaoService.GetById(idPermissao);
        }

    }
}
