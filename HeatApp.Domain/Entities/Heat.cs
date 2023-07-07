namespace HeatApp.Domain.Entities;

public class Heat : BaseEntity
{
    public double HeatValue { get; set; }
    public string DeviceId { get; set; }
}