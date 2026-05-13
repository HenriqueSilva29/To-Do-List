using static Domain.Entidades.Tarefa;

namespace Application.Funcionalidades.Tarefas.Visoes
{
    public class SubtarefaView
    {
        public int CodigoTarefa { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTimeOffset DataCriacao { get; set; }
        public DateTimeOffset? DataVencimento { get; set; }
        public DateOnly DataTarefa { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFim { get; set; }
        public EnumStatusTarefa Status { get; set; }
        public EnumPrioridadeTarefa Prioridade { get; set; }
        public EnumCategoriaTarefa Categoria { get; set; }
        public int? CodigoTarefaPai { get; set; }
    }
}
