using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Books;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PruebaEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ISvBook _svBook;
        public BooksController(ISvBook svBook)
        {
            _svBook = svBook;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _svBook.GetAllBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _svBook.GetBookById(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _svBook.AddBook(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book book)
        {
            _svBook.UpdateBook(id, new Book
            {
                Title = book.Title,
                AuthorId = book.AuthorId
            });
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svBook.DeleteBook(id);
        }
    }
}
