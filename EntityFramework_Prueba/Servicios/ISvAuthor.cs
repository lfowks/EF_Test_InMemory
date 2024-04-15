using Entidades;

namespace EntityFramework_Prueba.Servicios
{
    public interface ISvAuthor
    {
        //READS
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);

        //WRITES
        public Author AddAuthor(Author author);
        public Author UpdateAuthor(int id, Author author);
        public void DeleteAuthor(int id);
    }
}
