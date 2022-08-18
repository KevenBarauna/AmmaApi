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

namespace Amma.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SegestaoController : Controller
    {
        private readonly ILogger<SegestaoController> _logger;
        private readonly ISugestaoService _sugestaoService;
        private readonly IMapper _mapper;

        public SegestaoController(ILogger<SegestaoController> logger, IMapper mapper, ISugestaoService sugestaoService)
        {
            _logger = logger;
            _mapper = mapper;
            _sugestaoService = sugestaoService;
        }

        private void EscreverLog(string nomeFuncao, Sugestao? sugestao)
        {
            // _logger.LogInformation($"### UsuarioController - ${nomeFuncao} - {usuario?.Id} - {usuario?.Nome} - {usuario?.Email} - {usuario?.Senha} - {usuario?.Cargo} - {usuario?.IdPermissao} - {usuario?.CodAvatar}");
        }

        [HttpGet]
        [Route("BuscarTodasSugestoes")]
        [Authorize]
        public List<Sugestao> GetAllSugestoes()
        {
            EscreverLog("GetAllSugestoes", null);
            return _mapper.Map<List<Sugestao>>(_sugestaoService.GetAllSugestoes());
        }

        [HttpPost]
        [Route("CriarSugestao")]
        [Authorize]
        public Sugestao CreateSugestao([FromBody] SugestaoDto sugestaoDto)
        {
            var sugestaoMapper = _mapper.Map<Sugestao>(sugestaoDto);
            EscreverLog("CreateSugestao", sugestaoMapper);
            return _sugestaoService.CreateSugestao(sugestaoMapper);
        }

        [HttpPut]
        [Route("EditarSugestao")]
        [Authorize]
        public Sugestao EditarSugestao([FromBody] SugestaoEditarDto sugestaoEditarDto)
        {
            var sugestaoMapper = _mapper.Map<Sugestao>(sugestaoEditarDto);
            EscreverLog("EditarSugestao", sugestaoMapper);
            return _sugestaoService.EditarSugestao(sugestaoMapper);
        }

        [HttpPut]
        [Route("votoPositivoSugestao")]
        [Authorize]
        public Sugestao votoPositivoSugestao([FromQuery] int idSugestao)
        {
            EscreverLog($"votoPositivoSugestao {idSugestao}", null);
            return _sugestaoService.EditarSugestaoVotoPositivo(idSugestao);
        }

        [HttpPut]
        [Route("votoPositivoNegativo")]
        [Authorize]
        public Sugestao votoPositivoNegativo([FromQuery] int idSugestao)
        {
            EscreverLog($"votoPositivoNegativo {idSugestao}", null);
            return _sugestaoService.EditarSugestaoVotoNegativo(idSugestao);
        }

        [HttpGet]
        [Route("BuscarSugestao")]
        [Authorize]
        public Sugestao BuscarSugestao([FromQuery] int idSugestao)
        {
            EscreverLog($"BuscarSugestao id: {idSugestao}", null);
            return _sugestaoService.GetSugestao(idSugestao);
        }

        [HttpDelete]
        [Route("DeletarSugestao")]
        [Authorize(Roles = "2")]
        public Sugestao DeletarSugestao([FromQuery] int idSugestao)
        {
            EscreverLog($"DeletarSugestao id: {idSugestao}", null);
            return _sugestaoService.DeletarSugestao(idSugestao);
        }

        [HttpGet]
        [Route("BuscarTopSugestoes")]
        [Authorize]
        public List<Sugestao> BuscarTopSugestoes()
        {
            EscreverLog($"BuscarTopSugestoes", null);
            return _sugestaoService.GetTopSugestoesPositivas();
        }

        [HttpGet]
        [Route("BuscarTopNegativas")]
        [Authorize]
        public List<Sugestao> BuscarTopNegativas()
        {
            EscreverLog($"BuscarTopSugestoes", null);
            return _sugestaoService.GetTopSugestoesNegativas();
        }
    }
}
