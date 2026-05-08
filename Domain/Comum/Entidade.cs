namespace Domain.Comum
{
    public abstract class Entidade<TId>
    {
        public virtual TId Id { get; protected set; } = default!;
    }
}
