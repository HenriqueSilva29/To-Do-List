using Application.Funcionalidades.Tarefas.Dtos;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class AtualizarStatusTarefaRequisicaoValidator : AbstractValidator<AtualizarStatusTarefaRequisicao>
    {
        public AtualizarStatusTarefaRequisicaoValidator()
        {
            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}
