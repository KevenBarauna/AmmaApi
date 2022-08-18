using Amma.Core.Domain.Entities;
using System.Linq;

namespace Amma.Infrastructure.Interfaces
{
    public interface ISugestaoRepository
    {
        public IQueryable<Sugestao> FindAll();
        public Sugestao Create(Sugestao sugestao);
        public Sugestao Update(Sugestao sugestao);
        public Sugestao GetById(long id);
        public Sugestao Delete(Sugestao sugestao);
        public IQueryable<Sugestao> GetTopVotosPositivos();
        public IQueryable<Sugestao> GetTopVotosNegativos();
    }
}
