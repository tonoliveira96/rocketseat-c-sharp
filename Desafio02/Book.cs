namespace Desafio02
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string Subject { get; set; } = String.Empty;
        public double Price { get; set; }
        public int StoqueAmount { get; set; }
    }
}
