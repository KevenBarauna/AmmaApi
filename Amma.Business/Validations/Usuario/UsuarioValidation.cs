using FluentValidation;
using System;
using Entities = Amma.Core.Domain.Entities;


namespace Amma.Business.Validations.Usuario
{
    public class UsuarioValidation : AbstractValidator<Entities.Usuario>
    {
        public UsuarioValidation()
        {
            // NOVO USUÁRIO
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Nome)).WithMessage("Nome tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Senha)).WithMessage("Senha tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.IdCargo.ToString())).WithMessage("Cargo tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.CodAvatar.ToString())).WithMessage("CodAvatar tá em branco cara");
            RuleFor(instance => instance).Must(i => !string.IsNullOrEmpty(i.Email)).WithMessage("Email tá em branco cara");
        }
    }
}

