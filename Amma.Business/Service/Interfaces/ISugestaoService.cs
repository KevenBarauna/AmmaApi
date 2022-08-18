using Amma.Core.Domain.Entities;
using Amma.Infrastructure.Data.Repository;
using Amma.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amma.Business.Service.Interfaces
{
    public interface ISugestaoService
    {
        public Sugestao CreateSugestao(Sugestao sugestao);
        public Sugestao EditarSugestao(Sugestao sugestao);
        public Sugestao GetSugestao(int idSugestao);
        public List<Sugestao> GetAllSugestoes();
        public Sugestao DeletarSugestao(int idSugestao);
        public Sugestao EditarSugestaoVotoPositivo(int idSugestao);
        public Sugestao EditarSugestaoVotoNegativo(int idSugestao);
        public List<Sugestao> GetTopSugestoesPositivas();
        public List<Sugestao> GetTopSugestoesNegativas();

    }
}
