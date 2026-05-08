using Application.Dtos.Paginacaos;
using FluentValidation;

namespace Application.Validacoes.Comum
{
    public class PaginacaoRequisicaoValidator<T> : AbstractValidator<T>
        where T : PaginacaoRequisicao
    {
        public PaginacaoRequisicaoValidator()
        {
            RuleFor(x => x.Pagina)
                .GreaterThan(0);

            RuleFor(x => x.QuantidadePorPagina)
                .InclusiveBetween(1, 100);
        }
    }
}
