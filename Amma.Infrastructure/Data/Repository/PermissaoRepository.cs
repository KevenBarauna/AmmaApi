using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Data.Repository
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<PermissaoRepository> _logger;

        public PermissaoRepository(Contexto contexto, ILogger<PermissaoRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }
        public List<Permissao> FindAll()
        {
            _logger.LogInformation("### PermissaoRepository - FindAll");
            return _contexto.permissao.ToList();
        }

        public Permissao GetById(long id)
        {
            _logger.LogInformation($"### PermissaoRepository - GetById : ${id}");
            return _contexto.permissao.Where(x => x.Id == id).FirstOrDefault();
        }

    }
}
