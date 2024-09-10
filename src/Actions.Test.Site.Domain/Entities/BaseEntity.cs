namespace Actions.Test.Site.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
       
        public DateTime CreatedAt { get; private set; } = DateTime.Now;


    }
}
