using Amma.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Amma.Api.Models.DTO
{
    public class SugestaoDto
    {
        public int Id { get; set; }
        public long IdUsuario { get; set; }
        public long IdCategoria { get; set; }
        public long IdStatus { get; set; }
        public bool IsAnonimo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }

    public class SugestaoEditarDto
    {
        public int Id { get; set; }
        public long IdCategoria { get; set; }
        public bool IsAnonimo { get; set; }
        public string Descricao { get; set; }

    }
}
