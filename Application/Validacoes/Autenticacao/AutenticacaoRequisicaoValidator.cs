using Application.Funcionalidades.Autenticacao.Dtos;
using FluentValidation;

namespace Application.Validacoes.Autenticacao
{
    public class AutenticacaoRequisicaoValidator : AbstractValidator<AutenticacaoRequisicao>
    {
        public AutenticacaoRequisicaoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(200);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
