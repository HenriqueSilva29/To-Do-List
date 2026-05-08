using Domain.Comum.ObjetosDeValor;
using Domain.Comum;
using Domain.Entidades;
using Domain.Enumeradores;
using Domain.Excecoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace Repository.ContextosEF
{
    public class ContextEF : DbContext
    {
        private readonly IAuditoriaContexto? _auditoriaContexto;

        public ContextEF(
            DbContextOptions<ContextEF> options,
            IAuditoriaContexto? auditoriaContexto = null) : base(options)
        {
            _auditoriaContexto = auditoriaContexto;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextEF).Assembly);
        }

        public override async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
        {
            try
            {
                var auditoriasTemp = PrepararAuditoria();

                var result = await base.SaveChangesAsync(cancellationToken);

                if (auditoriasTemp.Any())
                {
                    foreach (var temp in auditoriasTemp)
                    {
                        var pk = temp.Entry
                            .Properties
                            .First(p => p.Metadata.IsPrimaryKey());

                        temp.Auditoria.IdEntidade = (int)pk.CurrentValue;

                        if (temp.Entry.State == EntityState.Unchanged && temp.Auditoria.Acao == EntityState.Added.ToString())
                        {
                            temp.Auditoria.Alteracoes = ObterAlteracoesAposInsert(temp.Entry);
                        }

                    }

                    Set<Auditoria>().AddRange(auditoriasTemp.Select(a => a.Auditoria));

                    await base.SaveChangesAsync(cancellationToken);
                }

                return result;
            }
            catch (Exception e)
            {
                throw new ExcecaoInfra(
                    EnumCodigosDeExcecao.ErroAoSalvarContexto,
                    "Erro ao salvar alteracoes no banco de dados",
                    e);
            }

        }

        private List<AuditoriaTemp> PrepararAuditoria()
        {
            ChangeTracker.DetectChanges();

            var auditorias = new List<AuditoriaTemp>();

            var entries = ChangeTracker
                .Entries()
                .Where(e =>
                  e.Entity is not Auditoria &&
                  (e.State == EntityState.Modified ||
                   e.State == EntityState.Added ||
                   e.State == EntityState.Deleted));

            foreach (var entry in entries)
            {
                var auditoria = new Auditoria
                {
                    Entidade = entry.Entity.GetType().Name,
                    Acao = entry.State.ToString(),
                    IdUsuario = ObterIdUsuarioAuditoria(),
                    Data = UtcDateTime.Now(),
                    Alteracoes = entry.State == EntityState.Added
                    ? string.Empty
                    : ObterAlteracoes(entry),
                };

                auditorias.Add(new AuditoriaTemp
                {
                    Auditoria = auditoria,
                    Entry = entry
                });
            }

            return auditorias;
        }

        private string ObterAlteracoes(EntityEntry entry, bool incluirPk = false)
        {
            var alteracoes = new Dictionary<string, object?>();

            foreach (var property in entry.Properties)
            {
                if (!incluirPk && property.Metadata.IsPrimaryKey())
                    continue;

                var antes = property.OriginalValue;
                var depois = property.CurrentValue;

                if (entry.State == EntityState.Added)
                {
                    alteracoes[property.Metadata.Name] = depois;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    alteracoes[property.Metadata.Name] = antes;
                }
                else if (property.IsModified && !Equals(antes, depois))
                {
                    alteracoes[property.Metadata.Name] = new
                    {
                        Antes = antes,
                        Depois = depois
                    };
                }
            }

            return JsonSerializer.Serialize(alteracoes);
        }

        private string ObterAlteracoesAposInsert(EntityEntry entry)
        {
            var alteracoes = new Dictionary<string, object?>();

            foreach (var property in entry.Properties)
            {
                if (property.Metadata.IsPrimaryKey())
                    continue; // recomendação

                alteracoes[property.Metadata.Name] = property.CurrentValue;
            }

            return JsonSerializer.Serialize(alteracoes);
        }

        private string ObterIdUsuarioAuditoria()
        {
            return string.IsNullOrWhiteSpace(_auditoriaContexto?.IdUsuario)
                ? "SISTEMA"
                : _auditoriaContexto.IdUsuario;
        }

    }
}

