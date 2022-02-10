using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Descricao { get; set; }
    }
}