using Amma.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amma.Api.Security
{
    public static class Autenticacao
    {
        public static async Task<ActionResult<dynamic>> AutenticarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                return new { usuario = false, token = "" };
            }
            else
            {
                var token = TokenService.GenerateToken(usuario);
                usuario.Senha = null;
                return new { usuario = usuario, token = token };
            }

        }
    }
}
