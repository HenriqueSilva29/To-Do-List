using Application.Funcionalidades.Tarefas.Dtos;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class AtualizarPrioridadeTarefaRequisicaoValidator : AbstractValidator<AtualizarPrioridadeTarefaRequisicao>
    {
        public AtualizarPrioridadeTarefaRequisicaoValidator()
        {
            RuleFor(x => x.Prioridade)
                .IsInEnum();
        }
    }
}
