using Application.Funcionalidades.Notificacoes.Filtros;
using Application.Funcionalidades.Notificacoes.Visoes;
using Application.Utils.Paginacao;

namespace Application.Funcionalidades.Notificacoes.Contratos.CasosDeUso
{
    public interface IListarNotificacoesCasoDeUso
    {
        Task<PaginacaoHelper<NotificacaoView>> ExecuteAsync(NotificacaoFiltroRequisicao filtro);
    }
}
