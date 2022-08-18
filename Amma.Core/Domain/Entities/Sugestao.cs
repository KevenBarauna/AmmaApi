using System;
using System.ComponentModel.DataAnnotations.Schema;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    public class Sugestao : BaseEntity
    {
        public int IdUsuario { get; set; }
        public int IdCategoria { get; set; }
        public int IdStatus { get; set; }
        public bool IsAnonimo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeVotosPositivos { get; set; }
        public int QuantidadeVotosNegativos { get; set; }
        public DateTime DataSugestao { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        [ForeignKey("idCategoria")]
        public Categoria Categoria { get; set; }
        [ForeignKey("idStatus")]
        public Status Status { get; set; }
    }
}