using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    public class Status: BaseEntity
    {
        public string Valor { get; set; }
        public string Descricao { get; set; }
    }
}