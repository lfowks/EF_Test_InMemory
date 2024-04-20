using Entidades;
using EntityFramework_Prueba.MyDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Prueba.Servicios
{
    internal class SvBook : ISvBook
    {
        private MyContext _myDbContext = default!;
        public SvBook()
        {
            _myDbContext = new MyContext();
        }

        public Book AddBook(Book book)
        {
            _myDbContext.Books.Add(book);
            _myDbContext.SaveChanges();

            return book;
        }

        public Book GetBookById(int id)
        {       //_myDbContext.Books.Find(id)
            return _myDbContext.Books.Include(x => x.Author).SingleOrDefault(x => x.Id == id);
        }

        #region Utils
        public void ShowAll()
        {
            List<Book> authors = _myDbContext.Books.ToList();
            foreach (var item in authors)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.AuthorId);

                Console.WriteLine(item.Title);
                Console.WriteLine("-----------------");
            }
        }
        #endregion
    }
}
