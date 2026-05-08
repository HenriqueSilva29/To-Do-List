using Application.Funcionalidades.Notificacoes.Filtros;
using Application.Validacoes.Comum;
using FluentValidation;

namespace Application.Validacoes.Notificacoes
{
    public class NotificacaoFiltroRequisicaoValidator : AbstractValidator<NotificacaoFiltroRequisicao>
    {
        public NotificacaoFiltroRequisicaoValidator()
        {
            Include(new PaginacaoRequisicaoValidator<NotificacaoFiltroRequisicao>());

            RuleFor(x => x.OrdenarPor)
                .Must((filtro, ordenarPor) => filtro.ObterCamposOrdenaveis().ContainsKey(ordenarPor))
                .WithMessage("Campo de ordenacao invalido.");

            RuleFor(x => x.Direcao)
                .Must(x => x.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
                           x.Equals("desc", StringComparison.OrdinalIgnoreCase))
                .WithMessage("Direcao deve ser asc ou desc.");

            RuleFor(x => x.CodigoNotificacao)
                .GreaterThan(0)
                .When(x => x.CodigoNotificacao.HasValue);

            RuleFor(x => x.Titulo)
                .MaximumLength(150);
        }
    }
}
