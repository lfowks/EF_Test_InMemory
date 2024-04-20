using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Prueba.Servicios
{
    public interface ISvBook
    {
        public Book AddBook(Book book);

        public Book GetBookById(int id);
    }
}
