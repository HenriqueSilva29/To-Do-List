using Application.Funcionalidades.Notificacoes.Contratos.CasosDeUso;
using Application.Funcionalidades.Notificacoes.Filtros;
using Application.Funcionalidades.Notificacoes.Visoes;
using Application.Utils.Paginacao;

namespace Application.Funcionalidades.Notificacoes.Servicos
{
    public class ServicoNotificacao : IServicoNotificacao
    {
        private readonly IListarNotificacoesCasoDeUso _listarNotificacoesUseCase;
        private readonly IContarNotificacoesNaoLidasCasoDeUso _contarNotificacoesNaoLidasUseCase;
        private readonly IMarcarNotificacaoComoLidaCasoDeUso _marcarNotificacaoComoLidaUseCase;
        private readonly IMarcarTodasNotificacoesComoLidasCasoDeUso _marcarTodasNotificacoesComoLidasUseCase;
        private readonly IExcluirNotificacaoCasoDeUso _excluirNotificacaoUseCase;
        private readonly IExcluirTodasNotificacoesCasoDeUso _excluirTodasNotificacoesUseCase;

        public ServicoNotificacao(
            IListarNotificacoesCasoDeUso listarNotificacoesUseCase,
            IContarNotificacoesNaoLidasCasoDeUso contarNotificacoesNaoLidasUseCase,
            IMarcarNotificacaoComoLidaCasoDeUso marcarNotificacaoComoLidaUseCase,
            IMarcarTodasNotificacoesComoLidasCasoDeUso marcarTodasNotificacoesComoLidasUseCase,
            IExcluirNotificacaoCasoDeUso excluirNotificacaoUseCase,
            IExcluirTodasNotificacoesCasoDeUso excluirTodasNotificacoesUseCase)
        {
            _listarNotificacoesUseCase = listarNotificacoesUseCase;
            _contarNotificacoesNaoLidasUseCase = contarNotificacoesNaoLidasUseCase;
            _marcarNotificacaoComoLidaUseCase = marcarNotificacaoComoLidaUseCase;
            _marcarTodasNotificacoesComoLidasUseCase = marcarTodasNotificacoesComoLidasUseCase;
            _excluirNotificacaoUseCase = excluirNotificacaoUseCase;
            _excluirTodasNotificacoesUseCase = excluirTodasNotificacoesUseCase;
        }

        public Task<PaginacaoHelper<NotificacaoView>> Listar(NotificacaoFiltroRequisicao filtro)
            => _listarNotificacoesUseCase.ExecuteAsync(filtro);

        public Task<int> ContarNaoLidas()
            => _contarNotificacoesNaoLidasUseCase.ExecuteAsync();

        public Task MarcarComoLida(int id)
            => _marcarNotificacaoComoLidaUseCase.ExecuteAsync(id);

        public Task MarcarTodasComoLidas()
            => _marcarTodasNotificacoesComoLidasUseCase.ExecuteAsync();

        public Task Excluir(int id)
            => _excluirNotificacaoUseCase.ExecuteAsync(id);

        public Task ExcluirTodas()
            => _excluirTodasNotificacoesUseCase.ExecuteAsync();
    }
}
