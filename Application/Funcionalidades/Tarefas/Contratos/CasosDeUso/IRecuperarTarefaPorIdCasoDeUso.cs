using Application.Funcionalidades.Tarefas.Visoes;

namespace Application.Funcionalidades.Tarefas.Contratos.CasosDeUso
{
    public interface IRecuperarTarefaPorIdCasoDeUso
    {
        Task<TarefaView> Executar(int id);
    }
}

