using Application.Funcionalidades.Tarefas.Dtos;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class DadosTarefaValidator<T> : AbstractValidator<T>
        where T : IDadosTarefaRequisicao
    {
        public DadosTarefaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Descricao)
                .MaximumLength(500);

            RuleFor(x => x.DataTarefa)
                .NotEmpty();

            RuleFor(x => x.HoraFim)
                .GreaterThan(x => x.HoraInicio)
                .WithMessage("Hora fim deve ser maior que hora inicio.");

            RuleFor(x => x.Prioridade)
                .IsInEnum();

            RuleFor(x => x.Categoria)
                .IsInEnum();
        }
    }
}
