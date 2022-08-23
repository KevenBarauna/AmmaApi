using Amma.Api.Models.DTO;
using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        private void EscreverLog(string nomeFuncao, string parametro)
        {
            _logger.LogInformation($"### SegestaoController - ${nomeFuncao} - {parametro}");
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
            EscreverLog("CreateSugestao", sugestaoDto.Titulo);
            return _sugestaoService.CreateSugestao(_mapper.Map<Sugestao>(sugestaoDto));
        }

        [HttpPut]
        [Route("EditarSugestao")]
        [Authorize]
        public Sugestao EditarSugestao([FromBody] SugestaoEditarDto sugestaoEditarDto)
        {
            EscreverLog("EditarSugestao", $" Id: {sugestaoEditarDto.Id}");
            return _sugestaoService.EditarSugestao(_mapper.Map<Sugestao>(sugestaoEditarDto));
        }

        [HttpPut]
        [Route("VotoPositivoSugestao")]
        [Authorize]
        public Sugestao VotoPositivoSugestao([FromQuery] int idSugestao)
        {
            EscreverLog("VotoPositivoSugestao", $"Id Sugestão: {idSugestao}");
            return _sugestaoService.EditarSugestaoVotoPositivo(idSugestao);
        }

        [HttpPut]
        [Route("VotoPositivoNegativo")]
        [Authorize]
        public Sugestao VotoPositivoNegativo([FromQuery] int idSugestao)
        {
            EscreverLog("VotoPositivoNegativo", $"Id Sugestão: {idSugestao}");
            return _sugestaoService.EditarSugestaoVotoNegativo(idSugestao);
        }

        [HttpGet]
        [Route("BuscarSugestao")]
        [Authorize]
        public Sugestao BuscarSugestao([FromQuery] int idSugestao)
        {
            EscreverLog("BuscarSugestao", $"Id Sugestão: {idSugestao}");
            return _sugestaoService.GetSugestao(idSugestao);
        }

        [HttpDelete]
        [Route("DeletarSugestao")]
        [Authorize(Roles = "2")]
        public Sugestao DeletarSugestao([FromQuery] int idSugestao)
        {
            EscreverLog("DeletarSugestao", $"Id Sugestão: {idSugestao}");
            return _sugestaoService.DeletarSugestao(idSugestao);
        }

        [HttpGet]
        [Route("BuscarTopSugestoesPositivas")]
        [Authorize]
        public List<Sugestao> BuscarTopSugestoesPositivas()
        {
            EscreverLog($"BuscarTopSugestoesPositivas", null);
            return _sugestaoService.GetTopSugestoesPositivas();
        }

        [HttpGet]
        [Route("BuscarTopSugestoesNegativas")]
        [Authorize]
        public List<Sugestao> BuscarTopSugestoesNegativas()
        {
            EscreverLog($"BuscarTopSugestoesNegativas", null);
            return _sugestaoService.GetTopSugestoesNegativas();
        }
    }
}
