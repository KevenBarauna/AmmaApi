using System.Collections.Generic;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Amma.Api.ViewModels;
using Amma.Api.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Amma.Api.Security;
using System.Threading.Tasks;

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

        private void EscreverLog(string nomeFuncao, string parametroRecebido)
        {
            _logger.LogInformation($"### UsuarioController - ${nomeFuncao} - {parametroRecebido}");
        }

        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        [Authorize(Roles = "2")]
        public List<UsuarioViewModel> GetAllUsuarios()

        {
            EscreverLog("GetAllUsuarios", null);
            return _mapper.Map<List<UsuarioViewModel>>(_usuarioService.GetAllUsuarios());
        }   

        [HttpPost]
        [Route("CriarUsuario")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> CreateUsuario([FromBody] UsuarioDto usuario)
        {
            EscreverLog("CreateUsuario", usuario.Nome);
            var novoUsuario = _usuarioService.CreateUsuario(_mapper.Map<Usuario>(usuario));
            var usuarioAutenticado = Autenticacao.AutenticarUsuario(novoUsuario);
            return usuarioAutenticado.Result.Value;

        }

        [HttpPut]
        [Route("EditarUsuario")]
        [Authorize]
        public Usuario EditarUsuario([FromBody] UsuarioDto usuario)
        {
            EscreverLog("EditarUsuario", usuario.Nome);
            return _usuarioService.EditarUsuario(_mapper.Map<Usuario>(usuario));
        }

        [HttpGet]
        [Route("BuscarUsuario")]
        [Authorize]
        public UsuarioViewModel BuscarUsuario([FromQuery] int idUsuario)
        {
            EscreverLog("BuscarUsuario", $"id: {idUsuario}");
            return _mapper.Map<UsuarioViewModel>(_usuarioService.GetUsuario(idUsuario));  
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        [Authorize]
        public Usuario DeletarUsuario([FromQuery] int idUsuario)
        {
            EscreverLog($"DeletarUsuario", $"id: {idUsuario}");
            return _usuarioService.DeletarUsuario(idUsuario);
        }

    }
}