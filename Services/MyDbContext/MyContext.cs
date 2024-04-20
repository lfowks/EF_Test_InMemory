using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>().HasData(
            //    new Author { Id = 1, Name = "Author 1", LastName = "Author Last Name 1" },
            //    new Author { Id = 2, Name = "Author 2", LastName = "Author Last Name 1" }
            //);
        }
    }
}
