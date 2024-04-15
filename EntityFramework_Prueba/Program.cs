// See https://aka.ms/new-console-template for more information

using Entidades;
using EntityFramework_Prueba.Servicios;

SvAuthor svAuthor = new SvAuthor();

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

Console.WriteLine("DeleteAuthor");
svAuthor.DeleteAuthor(1);

Author newAuthorUpdate = new Author();

newAuthorUpdate.Name = "Author 2 - Update";
newAuthorUpdate.LastName = "Author LastName 2 - Update";

svAuthor.UpdateAuthor(2, newAuthorUpdate);

svAuthor.ShowAll();
