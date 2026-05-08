using Application.Emails;
using Application.Funcionalidades.Autenticacao.Contratos.CasosDeUso;
using Application.Funcionalidades.Lembretes.Contratos.CasosDeUso;
using Application.Interfaces.Email;
using Application.Interfaces.Messaging;
using Infra.Autenticacao;
using Infra.BackgroundJobs.Hangfire.Jobs.Lembretes;
using Infra.Messaging.RabbitMQ.Channels;
using Infra.Messaging.RabbitMQ.Connections;
using Infra.Messaging.RabbitMQ.Consumidores;
using Infra.Messaging.RabbitMQ.Consumidores.Notificacoes;
using Infra.Messaging.RabbitMQ.Publicadores;
using Infra.Messaging.RabbitMQ.Topology;
using Infra.Messaging.RabbitMQ.Topology.Topologies.Notificacoes;
using Infra.Messaging.RabbitMQ.Topology.Topologies.Tarefas;
using Infra.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configuracao
{
    public static class InfraDependencyInjectionExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddScoped<LembreteEmailCompose>();
            services.AddScoped<IEmail, Email>();
            services.AddScoped<IHashSenhaCasoDeUso, HashSenha>();
            services.AddScoped<IVerificarSenhaCasoDeUso, VerificarSenha>();
            services.AddScoped<IAgendadorJobLembrete, AgendarLembreteJobScheduler>();

            return services;
        }

        public static IServiceCollection AddRabbitMessaging(this IServiceCollection services)
        {
            services.AddScoped<IRabbitEventPublisher, RabbitEventPublisher>();
            services.AddSingleton<IRabbitConnection, RabbitConnection>();
            services.AddSingleton<IRabbitChannelFactory, RabbitChannelFactory>();
            services.AddScoped<IRabbitTopologyInitializer, RabbitTopologyInitializer>();
            services.AddScoped<IRabbitTopology, GerarLembreteTopology>();
            services.AddScoped<IRabbitTopology, NotificacaoCriadaTopology>();

            return services;
        }

        public static IServiceCollection AddNotificacaoRabbitConsumer(this IServiceCollection services)
        {
            services.AddHostedService<RabbitInitializerHostedService>();
            services.AddHostedService<RabbitConsumerHostedService>();
            services.AddSingleton<IMessageConsumer, NotificacaoCriadaConsumer>();

            return services;
        }
    }
}
