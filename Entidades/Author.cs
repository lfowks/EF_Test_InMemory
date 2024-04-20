namespace Entidades
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //Book Relationship
        public List<Book> Books { get; set; }
    }
}