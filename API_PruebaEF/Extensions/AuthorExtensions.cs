using API_PruebaEF.ViewModels;
using Entidades;

namespace API_PruebaEF.Extensions
{
    public static class AuthorExtensions
    {
        public static Author ToAuthor(this AuthorVm authorVm)
        {
            Author author = new()
            {
                Name = authorVm.Name,
                LastName = authorVm.LastName,
                Age = authorVm.Age
            };

            return author;
        }

        public static AuthorVm ToAuthorVm(this Author author)
        {
            AuthorVm authorVm = new()
            {
                Name = author.Name,
                LastName = author.LastName,
                Age = author.Age
            };

            return authorVm;
        }

        public static AuthorGetVm ToAuthorGetVm(this Author author)
        {
            AuthorGetVm authorVm = new()
            {
                FullName = $"{author.Name} {author.LastName}",
                Age = author.Age
            };

            return authorVm;
        }
    }
}
