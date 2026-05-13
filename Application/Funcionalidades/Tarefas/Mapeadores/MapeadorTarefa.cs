using Application.Funcionalidades.Tarefas.Dtos;
using Application.Funcionalidades.Tarefas.Visoes;
using Domain.Comum.ObjetosDeValor;
using Domain.Entidades;

namespace Application.Funcionalidades.Tarefas.Mapeadores
{
    public static class MapeadorTarefa
    {
        // DTO para ENTIDADE
        public static Tarefa MapCriarTarafaParaEntidade(this CriarTarefaRequisicao dto)
        {
            return new Tarefa
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataCriacao = UtcDateTime.Now(),
                DataTarefa = dto.DataTarefa,
                HoraInicio = dto.HoraInicio,
                HoraFim = dto.HoraFim,
                Prioridade = dto.Prioridade,
                Categoria = dto.Categoria
            };
        }

        public static Tarefa MapCriarTarafaParaTarefa(this CriarTarefaRequisicao dto)
        {
            return dto.MapCriarTarafaParaEntidade();
        }

        public static Tarefa MapAtualizarTarefaParaEntidade(this AtualizarTarefaRequisicao dto, Tarefa tarefa)
        {
            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.DataTarefa = dto.DataTarefa;
            tarefa.HoraInicio = dto.HoraInicio;
            tarefa.HoraFim = dto.HoraFim;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.Categoria = dto.Categoria;
            tarefa.AtualizarStatus(dto.Status);

            return tarefa;
        }

        public static Tarefa AtualizarTarefaDto(Tarefa tarefa, AtualizarTarefaRequisicao dto)
        {
            return dto.MapAtualizarTarefaParaEntidade(tarefa);
        }

        // ENTIDADE para VIEW
        public static TarefaView MapEntidadeParaTarefaView(this Tarefa tarefa, bool incluirSubtarefas = false)
        {
            return new TarefaView
            {
                CodigoTarefa = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataVencimento = tarefa.DataVencimento.Value == default ? null : tarefa.DataVencimento.Value,
                DataTarefa = tarefa.DataTarefa,
                HoraInicio = tarefa.HoraInicio,
                HoraFim = tarefa.HoraFim,
                Status = tarefa.Status,
                Prioridade = tarefa.Prioridade,
                Categoria = tarefa.Categoria,
                CodigoTarefaPai = tarefa.CodigoTarefaPai,
                TotalSubtarefas = tarefa.SubTarefas?.Count ?? 0,
                SubtarefasConcluidas = tarefa.SubTarefas?.Count(st => st.Status == Tarefa.EnumStatusTarefa.Concluida) ?? 0,
                SubTarefas = incluirSubtarefas
                    ? tarefa.SubTarefas?
                        .OrderBy(st => st.DataCriacao.Value)
                        .Select(st => st.MapEntidadeParaSubtarefaView())
                        .ToList() ?? []
                    : []
            };
        }
    }
}
