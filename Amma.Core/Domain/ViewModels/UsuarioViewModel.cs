using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities;

namespace Amma.Core.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }     
        public string Email { get; set; }
        public string Cargo { get; set; }
        public long CodAvatar { get; set; }
        public Permissao permissao { get; set; }
    }
}