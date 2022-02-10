using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    [Table("usuario")]
    public class Usuario: BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("cargo")]
        public string Cargo { get; set; }
        [Column("codAvatar")]
        public int CodAvatar { get; set; }

        [Column("idPermissao")]
        public int IdPermissao { get; set; }
        [ForeignKey("IdPermissao")]
        public Permissao permissao { get; set; }

    }
}