using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    public class Sugestao : BaseEntity
    {
        public long IdUsuario { get; set; }
        public long IdCategoria { get; set; }
        public long IdStatus { get; set; }
        public bool IsAnonimo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public long QuantidadeVotos { get; set; }
        public DateTime DataSugestao { get; set; }
    }
}