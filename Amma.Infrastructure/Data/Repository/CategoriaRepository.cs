using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Amma.Infrastructure.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<CategoriaRepository> _logger;

        public CategoriaRepository(Contexto contexto, ILogger<CategoriaRepository> logger)
        {
            _logger = logger;
            _contexto = contexto;
        }
        public List<Categoria> FindAll()
        {
            _logger.LogInformation("### CategoriaRepository - FindAll");
            return _contexto.categoria.ToList();
        }

        public Categoria GetById(long id)
        {
            _logger.LogInformation($"### CategoriaRepository - GetById : ${id}");
            return _contexto.categoria.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
