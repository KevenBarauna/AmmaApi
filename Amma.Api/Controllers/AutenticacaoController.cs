using Amma.Api.Models.DTO;
using Amma.Api.Security;
using Amma.Api.ViewModels;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly ILogger<AutenticacaoController> _logger;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public AutenticacaoController(ILogger<AutenticacaoController> logger, IMapper mapper, IUsuarioService usuarioService)
        {
            _logger = logger;
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Login([FromQuery] string usuarioNome, string usuarioSenha)
        {
            _logger.LogInformation($"### AutenticacaoController - Login");
            var usuario = _usuarioService.GetUsuarioByLogin(usuarioNome, usuarioSenha);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            else
            {
                var token = TokenService.GenerateToken(usuario);
                usuario.Senha = null;
                return new { usuario = usuario, token = token };
            }

        }

    }
}
