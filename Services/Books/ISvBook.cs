using Entidades;

namespace Services.Books
{
    public interface ISvBook
    {
        public List<Book> GetAllBooks();
        public Book AddBook(Book book);
        public Book UpdateBook(int id, Book book);

        public void DeleteBook(int id);

        public Book GetBookById(int id);

        public List<Book> AddBooks(List<Book> books);
    }
}
