using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Business.Service
{
    public class PermissaoService : IPermissaoService
    {
        private readonly ILogger<PermissaoService> _logger;
        private readonly IPermissaoRepository _permissaoRepository;


        public PermissaoService(IPermissaoRepository permissaoRepository, ILogger<PermissaoService> logger)
        {
            _logger = logger;
            _permissaoRepository = permissaoRepository;
        }

        public Permissao GetById(int idPermissao)
        {
            _logger.LogInformation($"### PermissaoService - GetById {idPermissao}");
            return _permissaoRepository.GetById(idPermissao);
        }

        public List<Permissao> GetAll()
        {
            _logger.LogInformation($"### PermissaoService - GetAll");
            return _permissaoRepository.FindAll();
        }

    }
}
