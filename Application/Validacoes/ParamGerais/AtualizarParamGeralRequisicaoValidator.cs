using Application.Funcionalidades.ParamGerais.Dtos;
using FluentValidation;

namespace Application.Validacoes.ParamGerais
{
    public class AtualizarParamGeralRequisicaoValidator : AbstractValidator<AtualizarParamGeralRequisicao>
    {
        public AtualizarParamGeralRequisicaoValidator()
        {
            RuleFor(x => x.QuantidadeDateTimeAntesDoInicio)
                .GreaterThan(0);

            RuleFor(x => x.QuantidadeDiasParaArquivamento)
                .GreaterThan(0);

            RuleFor(x => x.Unidade)
                .IsInEnum();

            RuleFor(x => x.ListagemPadraoDeTarefas)
                .IsInEnum();

            RuleFor(x => x.TelaInicial)
                .IsInEnum();

            RuleFor(x => x.PrimeiroDiaDaSemana)
                .IsInEnum();

            RuleFor(x => x.Email)
                .EmailAddress()
                .MaximumLength(200)
                .When(x => !string.IsNullOrWhiteSpace(x.Email));

            RuleFor(x => x.Telefone)
                .MaximumLength(30);
        }
    }
}
