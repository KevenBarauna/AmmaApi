using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Data.Repository
{
    public class SugestaoRepository : ISugestaoRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<SugestaoRepository> _logger;

        public SugestaoRepository(Contexto contexto, ILogger<SugestaoRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }
        public IQueryable<Sugestao> FindAll()
        {
            _logger.LogInformation("### SugestaoRepository - FindAll");
            return _contexto.sugestao;
        }

        public Sugestao Create(Sugestao sugestao)
        {
            _logger.LogInformation("### SugestaoRepository - Create");
            _contexto.sugestao.Add(sugestao);
            _contexto.SaveChanges();
            return sugestao;
        }

        public Sugestao Update(Sugestao sugestao)
        {
            _logger.LogInformation("### SugestaoRepository - Update");
            _contexto.sugestao.Update(sugestao);
            _contexto.SaveChanges();
            return sugestao;
        }

        public Sugestao GetById(long id)
        {
            _logger.LogInformation($"### SugestaoRepository - GetById : ${id}");
            return _contexto.sugestao.Where(u => u.Id == id).FirstOrDefault();
        }

        public Sugestao Delete(Sugestao sugestao)
        {
            _logger.LogInformation($"### SugestaoRepository - Delete : ${sugestao?.Id}");
            _contexto.sugestao.Remove(sugestao);
            _contexto.SaveChanges();
            return sugestao;
        }

        public IQueryable<Sugestao> GetTopVotosPositivos()
        {
            _logger.LogInformation($"### SugestaoRepository - GetTopVotosPositivos");
            return _contexto.sugestao.OrderBy(u => u.QuantidadeVotosPositivos);
        }

        public IQueryable<Sugestao> GetTopVotosNegativos()
        {
            _logger.LogInformation($"### SugestaoRepository - GetTopVotosNegativos");
            return _contexto.sugestao.OrderBy(u => u.QuantidadeVotosNegativos);
        }

    }
}
