namespace Lancheria.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
