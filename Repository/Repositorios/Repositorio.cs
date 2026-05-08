using Domain.Comum;
using Microsoft.EntityFrameworkCore;
using Repository.ContextosEF;

namespace Repository.Repositorios
{

    public abstract class Repositorio<T, TId> : IRepositorio<T, TId>
    where T : Entidade<TId>
    {
        public readonly ContextEF _context;
        private readonly DbSet<T> _dbSet;

        public Repositorio(ContextEF context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IQueryable<T> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public virtual void Adicionar(T entity)
        {
             _dbSet.Add(entity);
        }

        public virtual void Atualizar(T entity)
        {
             _dbSet.Update(entity);
        }

        public virtual void Remover(T entity)
        {
             _dbSet.Remove(entity);
        }

        public virtual async Task<T?> RecuperarPorIdAsync(TId id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id!.Equals(id));
        }

    }
}

