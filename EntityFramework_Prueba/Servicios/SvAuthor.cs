using Entidades;
using EntityFramework_Prueba.MyDbContext;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Prueba.Servicios
{
    public class SvAuthor : ISvAuthor
    {
        private MyContext _myDbContext = default!; 
        public SvAuthor()
        {
            _myDbContext = new MyContext();
        }

        #region Reads
        public List<Author> GetAllAuthors()
        {
            return _myDbContext.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {       //_myDbContext.Authors.Find(id)
            return _myDbContext.Authors.Include(x => x.Books).SingleOrDefault(x => x.Id == id);
        }
        #endregion

        #region Writes
        public Author AddAuthor(Author author)
        {
            _myDbContext.Authors.Add(author);
            _myDbContext.SaveChanges();

            return author;
        }
        public void DeleteAuthor(int id)
        {
            Author deleteAuthor = _myDbContext.Authors.Find(id);

            if (deleteAuthor is not null)
            {
                _myDbContext.Authors.Remove(deleteAuthor);
                _myDbContext.SaveChanges();
            }
        }
        public Author UpdateAuthor(int id, Author newAuthor)
        {
            Author updateAuthor = _myDbContext.Authors.Find(id);

            if (updateAuthor is not null)
            {
                updateAuthor.Name = newAuthor.Name;
                updateAuthor.LastName = newAuthor.LastName;

                _myDbContext.Authors.Update(updateAuthor);
                _myDbContext.SaveChanges();
            }

            return updateAuthor;

        }

        #endregion

        #region Utils
        public void ShowAll()
        {
            List<Author> authors = GetAllAuthors();
            foreach (var item in authors)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.LastName);
                Console.WriteLine("-----------------");
            }
        }
        #endregion

    }
}
