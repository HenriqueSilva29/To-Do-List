using Domain.Entidades;

namespace Application.Funcionalidades.ParamGerais.Visoes
{
    public class ParamGeralView
    {
        public int Id { get; set; }
        public int CodigoUsuario { get; set; }
        public bool NotificarTarefasAntesDoInicio { get; set; }
        public int QuantidadeDateTimeAntesDoInicio { get; set; }
        public EnumUnidadeTempo Unidade { get; set; }
        public bool ReforcarlembreteNoProprioDia { get; set; }
        public bool ReceberNotificacaoPorEmail { get; set; }
        public bool ReceberNotificacaoPorWhatsApp { get; set; }
        public bool ReceberResumoDiario { get; set; }
        public TimeOnly HorarioResumoDiario { get; set; }
        public bool ArquivamentoAutomaticoTarefasConcluidas { get; set; }
        public bool ArquivarTarefasConcluidas { get; set; }
        public int QuantidadeDiasParaArquivamento { get; set; }
        public EnumListagemPadraoDeTarefas ListagemPadraoDeTarefas { get; set; }
        public EnumTelaInicial TelaInicial { get; set; }
        public EnumPrimeiroDiaDaSemana PrimeiroDiaDaSemana { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
    }
}
