using System;
using Amma.Core.Domain.Error;
using System.Collections.Generic;
using Message = Amma.Core.Domain.Constants.Message;
using Entities = Amma.Core.Domain.Entities;

namespace Amma.Business.Validations.Usuario
{
    public class UsuarioValidations
    {

        public List<ErrorField> ValidarNovoUsuario(Entities.Usuario usuario)
        {
            List<ErrorField> errosList = new List<ErrorField>();

            if (String.IsNullOrEmpty(usuario.Nome)) {
                errosList.Add(new ErrorField("Nome", Message.MSG_CAMPO_OBRIGATORIO_NOME));
            }
            if (String.IsNullOrEmpty(usuario.Senha))
            {
                errosList.Add(new ErrorField("Senha", Message.MSG_CAMPO_OBRIGATORIO_SENHA));
            }
            if (String.IsNullOrEmpty(usuario.Cargo))
            {
                errosList.Add(new ErrorField("Cargo", Message.MSG_CAMPO_OBRIGATORIO_CARGO));
            }
            if (String.IsNullOrEmpty(usuario.CodAvatar.ToString()))
            {
                errosList.Add(new ErrorField("CodAvatar", Message.MSG_CAMPO_OBRIGATORIO_AVATAR));
            }
            if (String.IsNullOrEmpty(usuario.Email))
            {
                errosList.Add(new ErrorField("Email", Message.MSG_CAMPO_OBRIGATORIO_EMAIL));
            }

            return errosList;

        }
    }
}