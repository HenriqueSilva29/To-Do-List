using Application.Funcionalidades.Tarefas.Dtos;
using Application.Funcionalidades.Tarefas.Dtos.Subtarefas;
using Application.Funcionalidades.Tarefas.Filtros;
using Application.Funcionalidades.Tarefas.Visoes;
using Application.Utils.Paginacao;

namespace Application.Funcionalidades.Tarefas.Servicos
{
    public interface IServicoTarefa
    {
        Task<TarefaResposta> AdicionarTarefa(CriarTarefaRequisicao dto);
        Task AtualizarTarefa(int id, AtualizarTarefaRequisicao dto);
        Task RemoverTarefa(int id);
        Task<PaginacaoHelper<TarefaView>> ListarTarefas(TarefaFiltroRequisicao parametros);
        Task AtualizarPrioridade(int id, AtualizarPrioridadeTarefaRequisicao dto);
        Task<TarefaView> ObterPorId(int id);
        Task<SubtarefaCriadaResposta> AdicionarSubtarefa(AdicionarSubtarefaRequisicao dto);
        Task AtualizarStatus(int id, AtualizarStatusTarefaRequisicao dto);
        Task<HistoricoTarefaResposta> RecuperarHistoricoPorId(int id);
    }
}
