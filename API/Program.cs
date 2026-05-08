using API.Configuracao;
using API.Filtros;
using API.Hubs;
using API.Middlewares;
using Application.Configuracao;
using Hangfire;
using Infra.Configuracao;
using Infra.BackgroundJobs.Hangfire.Dashboard;
using Microsoft.OpenApi.Models;
using Repository.Configuracao;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true)
    .AddJsonFile(
        $"appsettings.{builder.Environment.EnvironmentName}.Local.json",
        optional: true,
        reloadOnChange: true);

ValidateRequiredConfiguration(builder.Configuration);

builder.Host.UseSerilogConfig();

builder.Services
    .AddRepository(builder.Configuration)
    .AddBackgroundJobs(builder.Configuration)
    .AddApplication()
    .AddInfra()
    .AddRabbitMessaging()
    .AddNotificacaoRabbitConsumer()
    .AddApiInfrastructure()
    .AddCookieAuthenticationConfig();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
});

builder.Services.AddRazorPages();
builder.Services.AddControllers(options =>
    {
        options.Filters.Add<FluentValidationFilter>();
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.MaxDepth = 32;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHangfireDashboard(
    "/hangfire",
    new DashboardOptions
    {
        Authorization = new[] { new HangfireAuthorizationFilter() }
    });

app.UseStaticFiles();
app.UseCors("AllowFrontend");
app.UseRouting();
app.UseMiddleware<RastreabilidadeMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificacaoHub>("/hubs/notificacoes");
app.MapRazorPages();

app.Run();

static void ValidateRequiredConfiguration(IConfiguration configuration)
{
    var missingKeys = new List<string>();

    Require("ConnectionStrings:DefaultConnection");
    Require("RabbitMQ:Uri");
    Require("Email:Host");
    Require("Email:Port");
    Require("Email:UserName");
    Require("Email:Password");
    Require("Email:FromEmail");
    Require("Email:FromName");

    if (missingKeys.Count > 0)
    {
        var message = new StringBuilder()
            .AppendLine("Configuracao obrigatoria ausente para iniciar a API.")
            .AppendLine("Revise os arquivos appsettings.Local.json / appsettings.{Environment}.Local.json.")
            .AppendLine("Chaves ausentes:");

        foreach (var key in missingKeys)
        {
            message.AppendLine($"- {key}");
        }

        throw new InvalidOperationException(message.ToString());
    }

    void Require(string key)
    {
        if (string.IsNullOrWhiteSpace(configuration[key]))
        {
            missingKeys.Add(key);
        }
    }
}
