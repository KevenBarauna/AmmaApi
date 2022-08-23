using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;

namespace Amma.Api.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }     
        public string Email { get; set; }
        public long CodAvatar { get; set; }
        public Cargo Cargo { get; set; }
        public Permissao permissao { get; set; }
    }
}