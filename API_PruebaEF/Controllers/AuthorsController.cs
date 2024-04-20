using Entidades;
using Microsoft.AspNetCore.Mvc;
using Services.Authors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_PruebaEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private ISvAuthor _svAuthor;
        public AuthorsController(ISvAuthor svAuthor)
        {
            _svAuthor = svAuthor;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _svAuthor.GetAllAuthors();
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _svAuthor.GetAuthorById(id);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] Author author)
        {
            _svAuthor.AddAuthor(new Author { 
               Name = author.Name, 
               LastName = author.LastName });
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author author)
        {
            _svAuthor.UpdateAuthor(id, new Author
            {
                Name = author.Name,
                LastName = author.LastName
            });
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svAuthor.DeleteAuthor(id);
        }
    }
}
