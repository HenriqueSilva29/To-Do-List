using Application.Funcionalidades.Usuarios.Dtos;
using FluentValidation;

namespace Application.Validacoes.Usuarios
{
    public class AtualizarNomeUsuarioRequisicaoValidator : AbstractValidator<AtualizarNomeUsuarioRequisicao>
    {
        public AtualizarNomeUsuarioRequisicaoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
