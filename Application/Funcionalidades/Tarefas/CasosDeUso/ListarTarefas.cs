using Application.Funcionalidades.Tarefas.Contratos.CasosDeUso;
using Application.Funcionalidades.Tarefas.Filtros;
using Application.Funcionalidades.Tarefas.Mapeadores;
using Application.Funcionalidades.Tarefas.Visoes;
using Application.Funcionalidades.UsuarioAutenticado.Servicos;
using Application.Utils.Filtro;
using Application.Utils.Ordenacao;
using Application.Utils.Paginacao;
using Application.Utils.Queryable;
using Repository.Repositorios.Tarefas;

namespace Application.Funcionalidades.Tarefas.CasosDeUso
{
    public class ListarTarefas : IListarTarefasCasoDeUso
    {
        private readonly IRepTarefa _rep;
        private readonly IServicoUsuarioAutenticado _servUsuarioAutenticado;

        public ListarTarefas(
            IRepTarefa rep,
            IServicoUsuarioAutenticado servUsuarioAutenticado)
        {
            _rep = rep;
            _servUsuarioAutenticado = servUsuarioAutenticado;
        }

        public async Task<PaginacaoHelper<TarefaView>> Executar(TarefaFiltroRequisicao parametros)
        {
            var idUsuario = _servUsuarioAutenticado.ObterIdUsuarioLogado();

            var query = _rep.QueryTarefasPrincipaisPorUsuario(idUsuario);

            query = query.AplicarFiltros(parametros);
            query = query.AplicarOrdenacao(parametros);

            var paginacao = await query.PaginarAsync(parametros.Pagina, parametros.QuantidadePorPagina);
            var itens = paginacao.Itens.Select(i => i.MapEntidadeParaTarefaView()).ToList();

            return new PaginacaoHelper<TarefaView>(
                itens,
                paginacao.PaginaAtual,
                paginacao.QuantidadePorPagina,
                paginacao.TotalItens);
        }
    }
}
