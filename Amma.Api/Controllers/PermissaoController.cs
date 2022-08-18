using Amma.Api.Models.DTO;
using Amma.Api.ViewModels;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissaoController : Controller
    {

        private readonly ILogger<PermissaoController> _logger;
        private readonly IPermissaoService _permissaoService;

        public PermissaoController(ILogger<PermissaoController> logger, IPermissaoService permissaoService)
        {
            _logger = logger;
            _permissaoService = permissaoService;
        }


        [HttpGet]
        [Route("BuscarTodasPermissoes")]
        [Authorize(Roles = "2")]
        public List<Permissao> GetAllPermissoes()
        {
            _logger.LogInformation($"### PermissaoController - GetAllPermissoes");
            return _permissaoService.GetAll();
        }


        [HttpGet]
        [Route("BuscarPermissao")]
        [Authorize(Roles = "2")]
        public Permissao BuscarPermissao([FromQuery] int idPermissao)
        {
            _logger.LogInformation($"### PermissaoController - BuscarPermissao: {idPermissao}");
            return _permissaoService.GetById(idPermissao);
        }

    }
}
