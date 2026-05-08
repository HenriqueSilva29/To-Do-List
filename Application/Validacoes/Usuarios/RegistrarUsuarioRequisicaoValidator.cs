using Application.Funcionalidades.Usuarios.Dtos;
using FluentValidation;

namespace Application.Validacoes.Usuarios
{
    public class RegistrarUsuarioRequisicaoValidator : AbstractValidator<RegistrarUsuarioRequisicao>
    {
        public RegistrarUsuarioRequisicaoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(100);
        }
    }
}
