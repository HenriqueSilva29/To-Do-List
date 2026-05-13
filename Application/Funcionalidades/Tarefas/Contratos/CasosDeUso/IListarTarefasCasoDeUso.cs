using Application.Funcionalidades.Tarefas.Filtros;
using Application.Funcionalidades.Tarefas.Visoes;
using Application.Utils.Paginacao;

namespace Application.Funcionalidades.Tarefas.Contratos.CasosDeUso
{
    public interface IListarTarefasCasoDeUso
    {
        public Task<PaginacaoHelper<TarefaView>> Executar(TarefaFiltroRequisicao parametros);
    }
}
