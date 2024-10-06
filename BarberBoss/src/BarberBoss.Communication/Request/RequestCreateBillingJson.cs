using BarberBoss.Communication.Enums;

namespace BarberBoss.Communication.Request;
public class RequestCreateBillingJson
{
    public string Title { get; set; } = string.Empty;
    public decimal value { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public PaymentType PaymentType { get; set; }
}

