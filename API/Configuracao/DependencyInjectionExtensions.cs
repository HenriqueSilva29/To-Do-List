using API.Autenticacao;
using API.Context;
using API.SignalR;
using Application.Funcionalidades.Notificacoes.Contratos.TempoReal;
using Application.Interfaces.Context;
using Application.Observabilidade;
using Domain.Comum;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SignalR;
using Serilog;

namespace API.Configuracao
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBackgroundJobs(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(
                    configuration.GetConnectionString("DefaultConnection"),
                    new SqlServerStorageOptions
                    {
                        PrepareSchemaIfNecessary = true,
                        QueuePollInterval = TimeSpan.FromSeconds(60)
                    });
            });

            return services;
        }

        public static IServiceCollection AddApiInfrastructure(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<UsuarioContexto>();
            services.AddScoped<IUsuarioContexto>(sp => sp.GetRequiredService<UsuarioContexto>());
            services.AddScoped<IAuditoriaContexto>(sp => sp.GetRequiredService<UsuarioContexto>());
            services.AddSingleton<ICorrelationContextAccessor, CorrelationContextAccessor>();
            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, SignalRUserIdProvider>();
            services.AddScoped<IGeradorClaimsUsuario, GeradorClaimsUsuario>();
            services.AddScoped<INotificacaoTempoReal, NotificacaoTempoReal>();

            return services;
        }

        public static IServiceCollection AddCookieAuthenticationConfig(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "organizaai_auth";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.SlidingExpiration = true;

                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.CompletedTask;
                        },
                        OnRedirectToAccessDenied = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();
            return services;
        }

        public static IHostBuilder UseSerilogConfig(this IHostBuilder host)
        {
            return host.UseSerilog((_, loggerConfiguration) =>
            {
                loggerConfiguration
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(
                        "logs/rabbit-log-.txt",
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [CorrelationId={CorrelationId}] [TraceId={TraceId}] {Message:lj}{NewLine}{Exception}");
            });
        }
    }
}
