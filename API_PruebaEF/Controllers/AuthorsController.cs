using API_PruebaEF.Extensions;
using API_PruebaEF.ViewModels;
using Entidades;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.Authors;
using System.Net;

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
        public IActionResult Get(int id)
        {
            try
            {
                Author author = _svAuthor.GetAuthorById(id);
                AuthorGetVm authorVm;

                if (author is null)
                {
                    return NotFound(new
                    {
                        code = HttpStatusCode.NotFound,
                        message = "Author Not Found."
                    });
                }

                authorVm = author.ToAuthorGetVm();

                return Ok(authorVm);
            }
            catch (Exception ex)
            {
                //GUARDO EN BITACORA

                return BadRequest();
            }
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public void Post([FromBody] AuthorVm authorVm)
        {
            Author newAuthor = authorVm.ToAuthor();

            _svAuthor.AddAuthor(newAuthor);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AuthorVm authorVm)
        {
            Author newAuthor = authorVm.ToAuthor();

            _svAuthor.UpdateAuthor(id, newAuthor);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _svAuthor.DeleteAuthor(id);
        }
    }
}
