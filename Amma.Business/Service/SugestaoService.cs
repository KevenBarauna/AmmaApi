using Amma.Business.Service.Interfaces;
using Amma.Business.Validations.Sugestao;
using Amma.Business.Validations.Usuario;
using Amma.Core.Domain.Entities;
using Amma.Core.Domain.Enum;
using Amma.Core.Domain.Error;
using Amma.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amma.Business.Service
{
    public class SugestaoService : ISugestaoService
    {
        private readonly ILogger<SugestaoService> _logger;
        private readonly ISugestaoRepository _sugestaoRepository;

        private SugestaoValidations _sugestaoValidations = new SugestaoValidations();

        public SugestaoService(ISugestaoRepository sugestaoRepository, ILogger<SugestaoService> logger)
        {
            _logger = logger;
            _sugestaoRepository = sugestaoRepository;
        }

        private void EscreverLog(string nomeFuncao, Sugestao? sugestao)
        {
            // _logger.LogInformation($"### UsuarioService - ${nomeFuncao} - {usuario?.Id} - {usuario?.Nome} - {usuario?.Email} - {usuario?.Senha} - {usuario?.Cargo} - {usuario?.IdPermissao} - {usuario?.CodAvatar}");
        }

        private void EscreverErro(string nomeFuncao, string mensagem)
        {
            // _logger.LogError($"### UsuarioService - ${nomeFuncao} - {mensagem}");
        }

        private Sugestao ConfigurarNovaSugestao(Sugestao sugestao)
        {
            sugestao.DataSugestao = DateTime.Today;
            sugestao.QuantidadeVotosPositivos = 0;
            sugestao.QuantidadeVotosNegativos = 0;
            sugestao.IdStatus = Convert.ToInt32(EnumStatus.AGUARDANDO);
            EscreverLog("ConfigurarNovaSugestao", sugestao);
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
            EscreverLog("ConfigurarEditarSugestao", sugestao);
            return sugestao;
        }

        public Sugestao CreateSugestao(Sugestao sugestao)
        {
            EscreverLog("CreateSugestao", sugestao);
            sugestao = ConfigurarNovaSugestao(sugestao);
            List<ErrorField> errosList = _sugestaoValidations.ValidarNovaSugestao(sugestao);

            if (errosList.Count > 0)
            {
                EscreverErro("CreateSugestao", $"Quantidade de erros na validação: {errosList.Count}");
                throw new Exception(errosList[0].Descricao);

            }

            return _sugestaoRepository.Create(sugestao);
        }

        public Sugestao EditarSugestao(Sugestao sugestao)
        {
            EscreverLog("EditarSugestao", sugestao);
            sugestao = ConfigurarEditarSugestao(sugestao);
            List<ErrorField> errosList = _sugestaoValidations.ValidarEditarSugestao(sugestao);

            if (errosList.Count > 0)
            {
                EscreverErro("CreateSugestao", $"Quantidade de erros na validação: {errosList.Count}");
                throw new Exception(errosList[0].Descricao);

            }

            return _sugestaoRepository.Update(sugestao);
        }

        public Sugestao EditarSugestaoVotoPositivo(int idSugestao)
        {
            var sugestaoAnterior = GetSugestao(idSugestao);
            sugestaoAnterior.QuantidadeVotosPositivos += 1;

            EscreverLog("EditarSugestaoVotoPositivo", sugestaoAnterior);

            return _sugestaoRepository.Update(sugestaoAnterior);
        }

        public Sugestao EditarSugestaoVotoNegativo(int idSugestao)
        {
            var sugestaoAnterior = GetSugestao(idSugestao);
            sugestaoAnterior.QuantidadeVotosNegativos += 1;

            EscreverLog("EditarSugestaoVotoNegativo", sugestaoAnterior);

            return _sugestaoRepository.Update(sugestaoAnterior);
        }

        public Sugestao GetSugestao(int idSugestao)
        {
            EscreverLog("GetSugestao", null);
            return _sugestaoRepository.GetById(idSugestao);
        }

        public List<Sugestao> GetAllSugestoes()
        {
            EscreverLog("GetAllSugestoes", null);
            var sugestoes = _sugestaoRepository.FindAll();
            if(sugestoes.ToList().Count > 0)
            {
                return sugestoes.Include(x => x.Usuario).Include(x => x.Status).Include(x => x.Categoria).ToList();
            }
            return sugestoes.ToList();
        }

        public Sugestao DeletarSugestao(int idSugestao)
        {
            EscreverLog("DeletarSugestao", null);
            Sugestao sugestao = GetSugestao(idSugestao);
            return _sugestaoRepository.Delete(sugestao);
        }

        public List<Sugestao> GetTopSugestoesPositivas()
        {
            EscreverLog("GetTopSugestoesPositivas", null);
            var sugestoes = _sugestaoRepository.GetTopVotosPositivos();
            if (sugestoes.ToList().Count > 0)
            {
                return sugestoes.Include(x => x.Usuario).Include(x => x.Status).Include(x => x.Categoria).ToList();
            }
            return sugestoes.ToList();
        }

        public List<Sugestao> GetTopSugestoesNegativas()
        {
            EscreverLog("GetTopSugestoesNegativas", null);
            var sugestoes = _sugestaoRepository.GetTopVotosNegativos();
            if (sugestoes.ToList().Count > 0)
            {
                return sugestoes.Include(x => x.Usuario).Include(x => x.Status).Include(x => x.Categoria).ToList();
            }
            return sugestoes.ToList();
        }
    }
}
