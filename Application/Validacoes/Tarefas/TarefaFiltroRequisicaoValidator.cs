using Application.Funcionalidades.Tarefas.Filtros;
using Application.Validacoes.Comum;
using FluentValidation;

namespace Application.Validacoes.Tarefas
{
    public class TarefaFiltroRequisicaoValidator : AbstractValidator<TarefaFiltroRequisicao>
    {
        public TarefaFiltroRequisicaoValidator()
        {
            Include(new PaginacaoRequisicaoValidator<TarefaFiltroRequisicao>());

            RuleFor(x => x.OrdenarPor)
                .Must((filtro, ordenarPor) => filtro.ObterCamposOrdenaveis().ContainsKey(ordenarPor))
                .WithMessage("Campo de ordenacao invalido.");

            RuleFor(x => x.Direcao)
                .Must(x => x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("desc", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Direcao deve ser asc ou desc.");

            RuleFor(x => x.CodigoTarefa)
                .GreaterThan(0)
                .When(x => x.CodigoTarefa.HasValue);

            RuleFor(x => x.CodigoTarefaPai)
                .GreaterThan(0)
                .When(x => x.CodigoTarefaPai.HasValue);
        }
    }
}
