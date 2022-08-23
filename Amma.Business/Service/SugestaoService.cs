using Amma.Business.Service.Interfaces;
using Amma.Business.Validations.Sugestao;
using Amma.Core.Domain.Entities;
using Amma.Core.Domain.Enum;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Business.Service
{
    public class SugestaoService : ISugestaoService
    {
        private readonly ILogger<SugestaoService> _logger;
        private readonly ISugestaoRepository _sugestaoRepository;

        public SugestaoService(ISugestaoRepository sugestaoRepository, ILogger<SugestaoService> logger)
        {
            _logger = logger;
            _sugestaoRepository = sugestaoRepository;
        }

        private void EscreverLog(string nomeFuncao, string parametro)
        {
            _logger.LogInformation($"### SugestaoService - ${nomeFuncao} - {parametro}");
        }

        private void EscreverLogErro(string nomeFuncao, string mensagem)
        {
            _logger.LogError($"### SugestaoService - ${nomeFuncao} - {mensagem}");
        }

        private Sugestao ConfigurarNovaSugestao(Sugestao sugestao)
        {
            sugestao.DataSugestao = DateTime.Today;
            sugestao.QuantidadeVotosPositivos = 0;
            sugestao.QuantidadeVotosNegativos = 0;
            sugestao.IdStatus = Convert.ToInt32(EnumStatus.AGUARDANDO);
            EscreverLog("ConfigurarNovaSugestao", sugestao.Titulo);
            return sugestao;
        }

        private Sugestao ConfigurarEditarSugestao(Sugestao sugestao)
        {
            var sugestaoAnterior = GetSugestao(sugestao.Id);

            sugestao.IdUsuario = sugestaoAnterior.IdUsuario;
            sugestao.IdCategoria = sugestaoAnterior.IdCategoria;
            sugestao.IdStatus = sugestaoAnterior.IdStatus;
            sugestao.Titulo = sugestaoAnterior.Titulo;
            sugestao.QuantidadeVotosPositivos = sugestaoAnterior.QuantidadeVotosPositivos;
            sugestao.QuantidadeVotosNegativos = sugestaoAnterior.QuantidadeVotosNegativos;
            sugestao.DataSugestao = sugestaoAnterior.DataSugestao;
            EscreverLog("ConfigurarEditarSugestao", sugestao.Titulo);
            return sugestao;
        }

        public Sugestao CreateSugestao(Sugestao sugestao)
        {
            EscreverLog("CreateSugestao", sugestao.Titulo);
            sugestao = ConfigurarNovaSugestao(sugestao);
            SugestaoValidations validator = new SugestaoValidations();
            var result = validator.Validate(sugestao);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    string mensagemErro = $"Propriedade: {failure.PropertyName} não é válido(a), Erro: {failure.ErrorMessage}";
                    EscreverLogErro("CreateSugestao", mensagemErro);
                    throw new Exception(mensagemErro);
                }
            }

            return _sugestaoRepository.Create(sugestao);
        }

        public Sugestao EditarSugestao(Sugestao sugestao)
        {
            EscreverLog("EditarSugestao", sugestao.Titulo);
            sugestao = ConfigurarEditarSugestao(sugestao);
            SugestaoValidations validator = new SugestaoValidations();
            var result = validator.Validate(sugestao);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    string mensagemErro = $"Propriedade: {failure.PropertyName} não é válido(a), Erro: {failure.ErrorMessage}";
                    EscreverLogErro("CreateSugestao", mensagemErro);
                    throw new Exception(mensagemErro);
                }
            }

            return _sugestaoRepository.Update(sugestao);
        }

        public Sugestao EditarSugestaoVotoPositivo(int idSugestao)
        {
            var sugestaoAnterior = GetSugestao(idSugestao);
            sugestaoAnterior.QuantidadeVotosPositivos += 1;

            EscreverLog("EditarSugestaoVotoPositivo", $"Id Sugestao: {idSugestao} - Quantidade de votos atual: {sugestaoAnterior.QuantidadeVotosPositivos}");
            return _sugestaoRepository.Update(sugestaoAnterior);
        }

        public Sugestao EditarSugestaoVotoNegativo(int idSugestao)
        {
            var sugestaoAnterior = GetSugestao(idSugestao);
            sugestaoAnterior.QuantidadeVotosNegativos += 1;

            EscreverLog("EditarSugestaoVotoNegativo", $"Id Sugestao: {idSugestao} - Quantidade de votos atual: {sugestaoAnterior.QuantidadeVotosNegativos}");

            return _sugestaoRepository.Update(sugestaoAnterior);
        }

        public Sugestao GetSugestao(int idSugestao)
        {
            EscreverLog("GetSugestao", $"Id: {idSugestao}");
            return _sugestaoRepository.GetById(idSugestao);
        }

        public List<Sugestao> GetAllSugestoes()
        {
            EscreverLog("GetAllSugestoes", null);
            var sugestoes = _sugestaoRepository.FindAll();
            return sugestoes.ToList();
        }

        public Sugestao DeletarSugestao(int idSugestao)
        {
            EscreverLog("DeletarSugestao", $"Id: {idSugestao}");
            Sugestao sugestao = GetSugestao(idSugestao);
            return _sugestaoRepository.Delete(sugestao);
        }

        public List<Sugestao> GetTopSugestoesPositivas()
        {
            EscreverLog("GetTopSugestoesPositivas", null);
            return _sugestaoRepository.GetTopVotosPositivos().ToList();
        }

        public List<Sugestao> GetTopSugestoesNegativas()
        {
            EscreverLog("GetTopSugestoesNegativas", null);
            return _sugestaoRepository.GetTopVotosNegativos().ToList();
        }
    }
}
