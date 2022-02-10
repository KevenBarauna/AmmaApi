using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    [Table("permissao")]
    public class Permissao : BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}