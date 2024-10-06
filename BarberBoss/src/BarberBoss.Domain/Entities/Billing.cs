namespace BarberBoss.Domain.Entities;
public class Billing
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
}