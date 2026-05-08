using Application.Funcionalidades.Tarefas.Dtos;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class AtualizarTarefaRequisicaoValidator : AbstractValidator<AtualizarTarefaRequisicao>
    {
        public AtualizarTarefaRequisicaoValidator()
        {
            Include(new DadosTarefaValidator<AtualizarTarefaRequisicao>());

            RuleFor(x => x.Status)
                .IsInEnum();
        }
    }
}
