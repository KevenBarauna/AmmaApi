using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Business.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ILogger<CategoriaService> _logger;
        private readonly ICategoriaRepository _categoriaRepository;


        public CategoriaService(ICategoriaRepository categoriaRepository, ILogger<CategoriaService> logger)
        {
            _logger = logger;
            _categoriaRepository = categoriaRepository;
        }

        public Categoria GetById(int idCategoria)
        {
            _logger.LogInformation($"### CategoriaService - GetById {idCategoria}");
            return _categoriaRepository.GetById(idCategoria);
        }

        public List<Categoria> GetAll()
        {
            _logger.LogInformation($"### CategoriaService - GetAll");
            return _categoriaRepository.FindAll();
        }
    }
}
