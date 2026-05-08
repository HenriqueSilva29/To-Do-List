using static Domain.Entidades.Tarefa;

namespace Application.Funcionalidades.Tarefas.Dtos
{
    public interface IDadosTarefaRequisicao
    {
        string Titulo { get; }
        string? Descricao { get; }
        DateOnly DataTarefa { get; }
        TimeOnly HoraInicio { get; }
        TimeOnly HoraFim { get; }
        EnumPrioridadeTarefa Prioridade { get; }
        EnumCategoriaTarefa Categoria { get; }
    }
}
