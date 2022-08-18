using FluentValidation;
using Entities = Amma.Core.Domain.Entities;

namespace Amma.Business.Validations.Sugestao
{
    public class SugestaoValidations : AbstractValidator<Entities.Sugestao>
    {
        public SugestaoValidations()
        {
            // NOVA SUGESTÃO
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.IdUsuario.ToString())).WithMessage("IdUsuario tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.IdCategoria.ToString())).WithMessage("IdCategoria tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.IdStatus.ToString())).WithMessage("IdStatus tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Titulo)).WithMessage("Titulo tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Descricao)).WithMessage("Descricao tá em branco cara");
        }
    }

    public class SugestaoEditarValidations : AbstractValidator<Entities.Sugestao>
    {
        public SugestaoEditarValidations()
        {
            // NOVA SUGESTÃO
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Id.ToString())).WithMessage("IdUsuario tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.IdCategoria.ToString())).WithMessage("IdCategoria tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Descricao)).WithMessage("Descricao tá em branco cara");
        }
    }
}
