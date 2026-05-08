using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository.ContextosEF;
using Repository.Repositorios.Auditorias;
using Repository.Repositorios.Lembretes;
using Repository.Repositorios.Notificacoes;
using Repository.Repositorios.ParamGerais;
using Repository.Repositorios.Tarefas;
using Repository.Repositorios.Usuarios;

namespace Repository.Configuracao
{
    public static class RepositoryDependencyInjectionExtensions
    {
        public static IServiceCollection AddRepository(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContextEF>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Repository")));

            services.AddScoped<IRepTarefa, RepTarefa>();
            services.AddScoped<IRepLembrete, RepLembrete>();
            services.AddScoped<IRepUsuario, RepUsuario>();
            services.AddScoped<IRepParamGeral, RepParamGeral>();
            services.AddScoped<IRepAuditoria, RepAuditoria>();
            services.AddScoped<IRepNotificacao, RepNotificacao>();

            return services;
        }
    }
}
