using System.ComponentModel.DataAnnotations.Schema;
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
        [Column("idCargo")]
        public int IdCargo { get; set; }
        [Column("codAvatar")]
        public int CodAvatar { get; set; }

        [Column("idPermissao")]
        public int IdPermissao { get; set; }
        [ForeignKey("IdPermissao")]
        public Permissao Permissao { get; set; }
        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

    }
}