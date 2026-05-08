using Application.Funcionalidades.Tarefas.Dtos.Subtarefas;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class AdicionarSubtarefaRequisicaoValidator : AbstractValidator<AdicionarSubtarefaRequisicao>
    {
        public AdicionarSubtarefaRequisicaoValidator()
        {
            Include(new DadosTarefaValidator<AdicionarSubtarefaRequisicao>());

            RuleFor(x => x.CodigoTarefaPai)
                .GreaterThan(0)
                .When(x => x.CodigoTarefaPai.HasValue);
        }
    }
}
