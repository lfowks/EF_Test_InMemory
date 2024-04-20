// See https://aka.ms/new-console-template for more information

using Entidades;
using EntityFramework_Prueba.Servicios;

SvAuthor svAuthor = new SvAuthor();
SvBook svBook = new SvBook();

svAuthor.GetAllAuthors();

Author newAuthor = new Author();

newAuthor.Name = "Author 1";
newAuthor.LastName = "Author LastName 1";

svAuthor.AddAuthor(newAuthor);

Author newAuthor2 = new Author();

newAuthor2.Name = "Author 2";
newAuthor2.LastName = "Author LastName 2";

svAuthor.AddAuthor(newAuthor2);

svAuthor.ShowAll();

Console.WriteLine("GetAuthorById");
Author authorFound = svAuthor.GetAuthorById(2);

if(authorFound is not null)
    Console.WriteLine(authorFound.Name);

Author newAuthorUpdate = new Author();

newAuthorUpdate.Name = "Author 2 - Update";
newAuthorUpdate.LastName = "Author LastName 2 - Update";

svAuthor.UpdateAuthor(2, newAuthorUpdate);

svAuthor.ShowAll();

Console.WriteLine("------------------- Books ---------------------");

List<Book> books = new List<Book>();

Book newBook = new Book()
{
    AuthorId = 2,
    Title = "Book 1 - Author 2"
};
books.Add(newBook);

Book newBook2 = new Book()
{
    AuthorId = 2,
    Title = "Book 2 - Author 2"
};
books.Add(newBook2);

Book newBook3 = new Book()
{
    AuthorId = 2,
    Title = "Book 3 - Author 2"
};
books.Add(newBook3);

Book newBook4 = new Book()
{
    AuthorId = 1,
    Title = "Book 4 - Author 1"
};
books.Add(newBook4);

svBook.AddBooks(books);

svBook.ShowAll();

Author author1 = svAuthor.GetAuthorById(1);
Author author2 = svAuthor.GetAuthorById(2);

Book book = svBook.GetBookById(1);

Author newAuthor3 = new Author();

newAuthor3.Name = "Author 3";
newAuthor3.LastName = "Author LastName 3";

Author author3 = svAuthor.AddAuthor(newAuthor3);

foreach (Book bookItem in books)
{
    bookItem.AuthorId = author3.Id;
    bookItem.Title = $"Book {bookItem.Id} - {author3.Name}";

    svBook.UpdateBook(bookItem.Id, bookItem);
}

svBook.ShowAll();