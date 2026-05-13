using Application.Funcionalidades.Tarefas.Dtos.Subtarefas;
using Application.Funcionalidades.Tarefas.Visoes;
using Domain.Comum.ObjetosDeValor;
using Domain.Entidades;

namespace Application.Funcionalidades.Tarefas.Mapeadores
{
    public static class MapeadorSubtarefa
    {
        // DTO para ENTIDADE
        public static Tarefa MapAdicionarSubtarefaParaEntidade(AdicionarSubtarefaRequisicao dto)
        {
            var tarefa = new Tarefa()
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataCriacao = UtcDateTime.Now(),
                DataTarefa = dto.DataTarefa,
                HoraInicio = dto.HoraInicio,
                HoraFim = dto.HoraFim,
                Prioridade = dto.Prioridade,
                Categoria = dto.Categoria,
                CodigoTarefaPai = dto.CodigoTarefaPai,
            };

            return tarefa;
        }

        public static Tarefa ParaSubtarefa(AdicionarSubtarefaRequisicao dto)
        {
            return MapAdicionarSubtarefaParaEntidade(dto);
        }

        //ENTIDADE para VIEW
        public static SubtarefaView MapEntidadeParaSubtarefaView(this Tarefa subtarefa)
        {
            return new SubtarefaView
            {
                CodigoTarefa = subtarefa.Id,
                Titulo = subtarefa.Titulo,
                Descricao = subtarefa.Descricao,
                DataCriacao = subtarefa.DataCriacao,
                DataVencimento = subtarefa.DataVencimento.Value == default ? null : subtarefa.DataVencimento.Value,
                DataTarefa = subtarefa.DataTarefa,
                HoraInicio = subtarefa.HoraInicio,
                HoraFim = subtarefa.HoraFim,
                Status = subtarefa.Status,
                Prioridade = subtarefa.Prioridade,
                Categoria = subtarefa.Categoria,
                CodigoTarefaPai = subtarefa.CodigoTarefaPai
            };
        }
    }
}


