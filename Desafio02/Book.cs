using Desafio02.Enums;

namespace Desafio02
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public Genre Genre { get; set; }
        public double Price { get; set; }
        public int StoqueAmount { get; set; }

        string[] TitlesArray =
        {
            "1984",
            "Cem Anos de Solidão",
            "O Senhor dos Anéis",
            "Harry Potter e a Pedra Filosofal",
            "O Pequeno Príncipe",
            "Crime e Castigo",
            "Orgulho e Preconceito",
            "A Revolução dos Bichos",
            "A Arte da Guerra",
            "Dom Quixote"
        };

        string[] AuthorsArray =
        {
            "George Orwell",
            "Gabriel García Márquez",
            "J.R.R. Tolkien",
            "J.K. Rowling",
            "Antoine de Saint-Exupéry",
            "Fiódor Dostoiévski",
            "Jane Austen",
            "George Orwell",
            "Sun Tzu",
            "Miguel de Cervantes"
        };

        public List<Book> ListAllBooks()
        {
            return CreateBookList();
        }

        private List<Book> CreateBookList()
        {
            var list = new List<Book>();
            var randomNumber = new Random();

            for (int i = 0; i < 10; i++)
            {
                double price = randomNumber.NextDouble() * 100;

                list.Add(new Book()
                {
                    Id = i,
                    Title = TitlesArray[i],
                    Author = AuthorsArray[i],
                    Genre = Genre.Action,
                    Price = double.Parse(price.ToString("0.00")),
                    StoqueAmount = randomNumber.Next(0, 100)
                });
            }
            return list;
        }

    }
}
