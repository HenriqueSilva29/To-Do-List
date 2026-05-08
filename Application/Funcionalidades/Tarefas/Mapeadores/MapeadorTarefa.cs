using Application.Funcionalidades.Tarefas.Dtos;
using Application.Funcionalidades.Tarefas.Visoes;
using Domain.Comum.ObjetosDeValor;
using Domain.Entidades;

namespace Application.Funcionalidades.Tarefas.Mapeadores
{
    public static class MapeadorTarefa
    {
        public static Tarefa ToTarefa(CriarTarefaRequisicao dto)
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

        public static Tarefa AtualizarTarefaDto(Tarefa tarefa, AtualizarTarefaRequisicao dto)
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

        public static TarefaView MapearParaView(Tarefa tarefa)
        {
            return new TarefaView
            {
                CodigoTarefa = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                Status = tarefa.Status,
                Prioridade = tarefa.Prioridade,
                Categoria = tarefa.Categoria,
                CodigoTarefaPai = tarefa.CodigoTarefaPai,
                SubTarefas = tarefa.SubTarefas?.Select(st => st.Id).ToList()
            };
        }
    }
}


