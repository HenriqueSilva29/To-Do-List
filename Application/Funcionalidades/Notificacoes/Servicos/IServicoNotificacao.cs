using Application.Funcionalidades.Notificacoes.Filtros;
using Application.Funcionalidades.Notificacoes.Visoes;
using Application.Utils.Paginacao;

namespace Application.Funcionalidades.Notificacoes.Servicos
{
    public interface IServicoNotificacao
    {
        Task<PaginacaoHelper<NotificacaoView>> Listar(NotificacaoFiltroRequisicao filtro);
        Task<int> ContarNaoLidas();
        Task MarcarComoLida(int id);
        Task MarcarTodasComoLidas();
        Task Excluir(int id);
        Task ExcluirTodas();
    }
}
