using Application.Funcionalidades.Tarefas.Dtos;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class CriarTarefaRequisicaoValidator : AbstractValidator<CriarTarefaRequisicao>
    {
        public CriarTarefaRequisicaoValidator()
        {
            Include(new DadosTarefaValidator<CriarTarefaRequisicao>());
        }
    }
}
