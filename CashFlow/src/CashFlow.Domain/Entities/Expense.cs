namespace CashFlow.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public Enums.PaymentType PaymentType { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public ICollection<Entities.Tag> Tags { get; set; } = new List<Entities.Tag>();
    }
}
