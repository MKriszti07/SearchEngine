namespace SearchEngine.Core.Domain.Common.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}
