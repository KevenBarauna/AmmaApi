using Amma.Core.Domain.Constants;
using Amma.Core.Domain.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Message = Amma.Core.Domain.Constants.Message;
using Entities = Amma.Core.Domain.Entities;

namespace Amma.Business.Validations.Sugestao
{
    public class SugestaoValidations
    {

        public List<ErrorField> ValidarNovaSugestao(Entities.Sugestao sugestao)
        {
            List<ErrorField> errosList = new List<ErrorField>();

            if (String.IsNullOrEmpty(sugestao.IdUsuario.ToString()))
            {
                errosList.Add(new ErrorField("IdUsuario", Message.MSG_CAMPO_OBRIGATORIO_ID_USUARIO));
            }
            if (String.IsNullOrEmpty(sugestao.IdCategoria.ToString()))
            {
                errosList.Add(new ErrorField("IdCategoria", Message.MSG_CAMPO_OBRIGATORIO_ID_CATEGORIA));
            }
            if (String.IsNullOrEmpty(sugestao.IdStatus.ToString()))
            {
                errosList.Add(new ErrorField("IdStatus", Message.MSG_CAMPO_OBRIGATORIO_ID_STATUS));
            }
            if (String.IsNullOrEmpty(sugestao.Titulo))
            {
                errosList.Add(new ErrorField("Titulo", Message.MSG_CAMPO_OBRIGATORIO_TITULO));
            }
            if (String.IsNullOrEmpty(sugestao.Descricao))
            {
                errosList.Add(new ErrorField("Descricao", Message.MSG_CAMPO_OBRIGATORIO_DESCRICAO));
            }

            return errosList;

        }

        public List<ErrorField> ValidarEditarSugestao(Entities.Sugestao sugestao)
        {
            List<ErrorField> errosList = new List<ErrorField>();

            if (String.IsNullOrEmpty(sugestao.Id.ToString()))
            {
                errosList.Add(new ErrorField("Id", Message.MSG_CAMPO_OBRIGATORIO_ID));
            }
            if (String.IsNullOrEmpty(sugestao.IdCategoria.ToString()))
            {
                errosList.Add(new ErrorField("IdCategoria", Message.MSG_CAMPO_OBRIGATORIO_ID_CATEGORIA));
            }
            if (String.IsNullOrEmpty(sugestao.Descricao))
            {
                errosList.Add(new ErrorField("Descricao", Message.MSG_CAMPO_OBRIGATORIO_DESCRICAO));
            }

            return errosList;

        }

    }
}
