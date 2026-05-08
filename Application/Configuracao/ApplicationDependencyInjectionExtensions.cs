using Application.Funcionalidades.Autenticacao.CasosDeUso;
using Application.Funcionalidades.Autenticacao.Contratos.CasosDeUso;
using Application.Funcionalidades.Autenticacao.Servicos;
using Application.Funcionalidades.Lembretes.CasosDeUso;
using Application.Funcionalidades.Lembretes.Contratos.CasosDeUso;
using Application.Funcionalidades.Notificacoes.CasosDeUso;
using Application.Funcionalidades.Notificacoes.Contratos.CasosDeUso;
using Application.Funcionalidades.Notificacoes.Contratos.TempoReal;
using Application.Funcionalidades.Notificacoes.Eventos;
using Application.Funcionalidades.Notificacoes.Servicos;
using Application.Funcionalidades.ParamGerais.CasosDeUso;
using Application.Funcionalidades.ParamGerais.Contratos.CasosDeUso;
using Application.Funcionalidades.ParamGerais.Servicos;
using Application.Funcionalidades.Tarefas.CasosDeUso;
using Application.Funcionalidades.Tarefas.CasosDeUso.Subtarefa;
using Application.Funcionalidades.Tarefas.Contratos.CasosDeUso;
using Application.Funcionalidades.Tarefas.Contratos.CasosDeUso.Subtarefas;
using Application.Funcionalidades.Tarefas.Eventos;
using Application.Funcionalidades.Tarefas.Servicos;
using Application.Funcionalidades.UsuarioAutenticado.CasosDeUso;
using Application.Funcionalidades.UsuarioAutenticado.Contratos.CasosDeUso;
using Application.Funcionalidades.UsuarioAutenticado.Servicos;
using Application.Funcionalidades.Usuarios.CasosDeUso;
using Application.Funcionalidades.Usuarios.Contratos.CasosDeUso;
using Application.Funcionalidades.Usuarios.Servicos;
using Application.Interfaces.Messaging;
using Application.Messaging.MessageHandlers;
using Application.Utils.Transacao;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuracao
{
    public static class ApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddApplicationUseCases();
            services.AddApplicationMessaging();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServicoTarefa, ServicoTarefa>();
            services.AddScoped<IServicoAutenticacao, ServicoAutenticacao>();
            services.AddScoped<IServicoParamGeral, ServicoParamGeral>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IServicoNotificacao, ServicoNotificacao>();
            services.AddScoped<IServicoUsuarioAutenticado, ServicoUsuarioAutenticado>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddApplicationUseCases(this IServiceCollection services)
        {
            services.AddScoped<IAdicionarTarefaCasoDeUso, AdicionarTarefaCasoDeUso>();
            services.AddScoped<IAtualizarPrioridadeTarefaCasoDeUso, AtualizarPrioridadeTarefaCasoDeUso>();
            services.AddScoped<IAtualizarTarefaCasoDeUso, AtualizarTarefaCasoDeUso>();
            services.AddScoped<IListarTarefasCasoDeUso, ListarTarefas>();
            services.AddScoped<IRemoverTarefaCasoDeUso, RemoverTarefaCasoDeUso>();
            services.AddScoped<IGerarLembreteCasoDeUso, TarefaCriadaGerarLembreteCasoDeUso>();
            services.AddScoped<ILoginCasoDeUso, LoginCasoDeUso>();
            services.AddScoped<IRegistrarUsuarioCasoDeUso, RegistrarUsuarioCasoDeUso>();
            services.AddScoped<IRecuperarTarefaPorIdCasoDeUso, RecuperarTarefaPorIdCasoDeUso>();
            services.AddScoped<IAdicionarSubtarefaCasoDeUso, AdicionarSubtarefaCasoDeUso>();
            services.AddScoped<IAtualizarStatusTarefaCasoDeUso, AtualizarStatusTarefaCasoDeUso>();
            services.AddScoped<IRecuperarHistoricoTarefaCasoDeUso, RecuperarHistoricoTarefaCasoDeUso>();
            services.AddScoped<IAgendarLembreteCasoDeUso, AgendarLembreteCasoDeUso>();
            services.AddScoped<IDispararLembreteCasoDeUso, DispararLembreteCasoDeUso>();
            services.AddScoped<IEnviarLembretePorEmailCasoDeUso, EnviarLembretePorEmailCasoDeUso>();
            services.AddScoped<IListarParamGeralCasoDeUso, ListarParamGeralCasoDeUso>();
            services.AddScoped<IAtualizarParamGeralCasoDeUso, AtualizarParamGeralCasoDeUso>();
            services.AddScoped<ICriarNotificacaoCasoDeUso, CriarNotificacaoCasoDeUso>();
            services.AddScoped<IListarNotificacoesCasoDeUso, ListarNotificacoesCasoDeUso>();
            services.AddScoped<IContarNotificacoesNaoLidasCasoDeUso, ContarNotificacoesNaoLidasCasoDeUso>();
            services.AddScoped<IMarcarNotificacaoComoLidaCasoDeUso, MarcarNotificacaoComoLidaCasoDeUso>();
            services.AddScoped<IMarcarTodasNotificacoesComoLidasCasoDeUso, MarcarTodasNotificacoesComoLidasCasoDeUso>();
            services.AddScoped<IExcluirNotificacaoCasoDeUso, ExcluirNotificacaoCasoDeUso>();
            services.AddScoped<IExcluirTodasNotificacoesCasoDeUso, ExcluirTodasNotificacoesCasoDeUso>();
            services.AddScoped<IAtualizarNomeUsuarioCasoDeUso, AtualizarNomeUsuarioCasoDeUso>();
            services.AddScoped<IObterIdUsuarioCasoDeUso, ObterIdUsuarioCasoDeUso>();
            services.AddScoped<INotificarUsuarioCasoDeUso, NotificarUsuarioCasoDeUso>();

            return services;
        }

        private static IServiceCollection AddApplicationMessaging(this IServiceCollection services)
        {
            services.AddScoped<IMessageDispatcher, MessageDispatcher>();
            services.AddScoped<IMessageHandler<TarefaCriadaEvento>, GerarLembreteMessageHandler>();
            services.AddScoped<IMessageHandler<NotificacaoCriadaEvento>, NotificacaoCriadaMessageHandler>();

            return services;
        }
    }
}
