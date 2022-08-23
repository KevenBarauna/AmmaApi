using Amma.Api.Security;
using Amma.Business.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            var usuarioAutenticado = Autenticacao.AutenticarUsuario(_usuarioService.GetUsuarioByLogin(usuarioNome, usuarioSenha));
            if (string.IsNullOrEmpty(usuarioAutenticado.Result.Value.token))
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }
            else
            {
                return usuarioAutenticado.Result.Value;
            }

        }

    }
}
