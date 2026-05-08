using Domain.Comum;

namespace Repository.Repositorios
{
    public interface IRepositorio<T, TId> where T : Entidade<TId>
    {
        IQueryable<T> AsQueryable();
        Task<T?> RecuperarPorIdAsync(TId id);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(T entity);
    }
}

