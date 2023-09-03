namespace Lancheria.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime LastUpdateDate { get; protected set; }
    }
}
