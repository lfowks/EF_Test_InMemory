using Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Services.MyDbContext
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
            //optionsBuilder.UseSqlServer("Server=TUFLW\\SQLEXPRESS;Database=apitest;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Author)
                .WithMany(author => author.Books);

        }
    }
}
