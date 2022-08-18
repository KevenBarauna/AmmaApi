using System.Collections.Generic;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Amma.Api.ViewModels;
using Amma.Api.Models.DTO;

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

        private void EscreverLog(string nomeFuncao, Usuario? usuario)
        {
            _logger.LogInformation($"### UsuarioController - ${nomeFuncao} - {usuario?.Id} - {usuario?.Nome} - {usuario?.Email} - {usuario?.Senha} - {usuario?.Cargo} - {usuario?.IdPermissao} - {usuario?.CodAvatar}");
        }

        [HttpGet]
        [Route("BuscarTodosUsuarios")]
        public List<UsuarioViewModel> GetAllUsuarios()
        {
            EscreverLog("GetAllUsuarios", null);
            return _mapper.Map<List<UsuarioViewModel>>(_usuarioService.GetAllUsuarios());
        }   

        [HttpPost]
        [Route("CriarUsuario")]
        public Usuario CreateUsuario([FromBody] UsuarioCadastrarDto usuario)
        {
            var usuarioMapper = _mapper.Map<Usuario>(usuario);
            EscreverLog("CreateUsuario", usuarioMapper);
            return _usuarioService.CreateUsuario(usuarioMapper);
        }

        [HttpPut]
        [Route("EditarUsuario")]
        public Usuario EditarUsuario([FromBody] UsuarioCadastrarDto usuario)
        {
            var usuarioMapper = _mapper.Map<Usuario>(usuario);
            EscreverLog("EditarUsuario", usuarioMapper);
            return _usuarioService.EditarUsuario(usuarioMapper);
        }

        [HttpGet]
        [Route("BuscarUsuario")]
        public Usuario BuscarUsuario([FromQuery] int idUsuario)
        {
            EscreverLog($"BuscarUsuario id: {idUsuario}", null);
            return _usuarioService.GetUsuario(idUsuario);
        }

        [HttpDelete]
        [Route("DeletarUsuario")]
        public Usuario DeletarUsuario([FromQuery] int idUsuario)
        {
            EscreverLog($"DeletarUsuario id: {idUsuario}", null);
            return _usuarioService.DeletarUsuario(idUsuario);
        }

    }
}