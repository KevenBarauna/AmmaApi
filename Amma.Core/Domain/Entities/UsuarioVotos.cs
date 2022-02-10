using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Core.Domain.Entities.Base;

namespace Amma.Core.Domain.Entities
{
    public class UsuarioVotos : BaseEntity
    {
        public long IdUsuario { get; set; }
        public long IdSugestao { get; set; }
    }
}