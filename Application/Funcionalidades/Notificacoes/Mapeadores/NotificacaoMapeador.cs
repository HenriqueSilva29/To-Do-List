using Application.Funcionalidades.Notificacoes.Visoes;
using Domain.Entidades;

namespace Application.Funcionalidades.Notificacoes.Mapeadores
{
    public static class NotificacaoMapeador
    {
        public static NotificacaoView MapEntidadeParaNotificacaoView(this Notificacao notificacao)
        {
            return new NotificacaoView
            {
                Id = notificacao.Id,
                Tipo = notificacao.Tipo,
                Titulo = notificacao.Titulo,
                Mensagem = notificacao.Mensagem,
                Lida = notificacao.Lida,
                DataCriacao = notificacao.DataCriacao.Value,
                DataLeitura = notificacao.DataLeitura.HasValue ? notificacao.DataLeitura.Value.Value : null
            };
        }
    }
}
