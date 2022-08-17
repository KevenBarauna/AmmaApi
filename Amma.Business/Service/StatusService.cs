using Amma.Business.Service.Interfaces;
using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Amma.Business.Service
{
    public class StatusService: IStatusService
    {
        private readonly ILogger<StatusService> _logger;
        private readonly IStatusRepository _statusRepository;


        public StatusService(IStatusRepository statusRepository, ILogger<StatusService> logger)
        {
            _logger = logger;
            _statusRepository = statusRepository;
        }

        public Status GetById(int idStatus)
        {
            _logger.LogInformation($"### StatusService - GetById {idStatus}");
            return _statusRepository.GetById(idStatus);
        }

        public List<Status> GetAll()
        {
            _logger.LogInformation($"### StatusService - GetAll");
            return _statusRepository.FindAll();
        }
    }
}
