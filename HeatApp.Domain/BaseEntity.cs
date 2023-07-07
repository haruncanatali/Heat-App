namespace HeatApp.Domain;

public class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTime.Now;
    }
    
    public long Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}