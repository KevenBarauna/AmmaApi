using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Amma.Api.ViewModels;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(ILogger<UsuarioController> logger, IMapper mapper, IUsuarioService usuarioService)
        {
            _logger = logger;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        public List<UsuarioViewModel> GetAllUsuarios()
        {
            _logger.LogInformation("#### UsuarioController - GetAllUsuarios ####");
            return _mapper.Map<List<UsuarioViewModel>>(_usuarioService.GetAllUsuarios());
            // return _usuarioService.GetAllUsuarios();
        }   

        [HttpPost]
        [Route("CriarUsuario")]
        public Usuario CreateUsuario([FromBody] Usuario usuario)
        {
            _logger.LogInformation("#### UsuarioController - CreateUsuario ####");
            return _usuarioService.CreateUsuario(usuario);
        }  

    }
}