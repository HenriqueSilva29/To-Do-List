using Application.Funcionalidades.ParamGerais.Dtos;
using Application.Funcionalidades.ParamGerais.Visoes;
using Domain.Entidades;

namespace Application.Funcionalidades.ParamGerais.Mapeadores
{
    public static class ParamGeralMapeador
    {
        public static ParamGeral AtualizarEntidade(ParamGeral entity, AtualizarParamGeralRequisicao dto)
        {
            entity.Atualizar(
                dto.NotificarTarefasAntesDoInicio,
                dto.QuantidadeDateTimeAntesDoInicio,
                dto.Unidade,
                dto.ReforcarlembreteNoProprioDia,
                dto.ReceberNotificacaoPorEmail,
                dto.ReceberNotificacaoPorWhatsApp,
                dto.ReceberResumoDiario,
                dto.HorarioResumoDiario,
                dto.ArquivamentoAutomaticoTarefasConcluidas,
                dto.ArquivarTarefasConcluidas,
                dto.QuantidadeDiasParaArquivamento,
                dto.ListagemPadraoDeTarefas,
                dto.TelaInicial,
                dto.PrimeiroDiaDaSemana,
                dto.Email,
                dto.Telefone);

            return entity;
        }

        public static ParamGeralView MapEntidadeParaParamGeralView(this ParamGeral entity)
        {
            return new ParamGeralView
            {
                Id = entity.Id,
                CodigoUsuario = entity.CodigoUsuario,
                NotificarTarefasAntesDoInicio = entity.NotificarTarefasAntesDoInicio,
                QuantidadeDateTimeAntesDoInicio = entity.QuantidadeDateTimeAntesDoInicio,
                Unidade = entity.Unidade,
                ReforcarlembreteNoProprioDia = entity.ReforcarlembreteNoProprioDia,
                ReceberNotificacaoPorEmail = entity.ReceberNotificacaoPorEmail,
                ReceberNotificacaoPorWhatsApp = entity.ReceberNotificacaoPorWhatsApp,
                ReceberResumoDiario = entity.ReceberResumoDiario,
                HorarioResumoDiario = entity.HorarioResumoDiario,
                ArquivamentoAutomaticoTarefasConcluidas = entity.ArquivamentoAutomaticoTarefasConcluidas,
                ArquivarTarefasConcluidas = entity.ArquivarTarefasConcluidas,
                QuantidadeDiasParaArquivamento = entity.QuantidadeDiasParaArquivamento,
                ListagemPadraoDeTarefas = entity.ListagemPadraoDeTarefas,
                TelaInicial = entity.TelaInicial,
                PrimeiroDiaDaSemana = entity.PrimeiroDiaDaSemana,
                Email = entity.Email,
                Telefone = entity.Telefone
            };
        }
    }
}
