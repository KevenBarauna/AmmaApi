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
    public class CategoriaController : Controller
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
        {
            _logger = logger;
            _categoriaService = categoriaService;
        }


        [HttpGet]
        [Route("BuscarTodasCategorias")]
        public List<Categoria> GetAllCategorias()
        {
            _logger.LogInformation($"### CategoriaController - GetAllCategorias");
            return _categoriaService.GetAll();
        }


        [HttpGet]
        [Route("BuscarPermissao")]
        public Categoria BuscarCategoria([FromQuery] int idCategoria)
        {
            _logger.LogInformation($"### CategoriaController - BuscarCategoria: {idCategoria}");
            return _categoriaService.GetById(idCategoria);
        }
    }
}
