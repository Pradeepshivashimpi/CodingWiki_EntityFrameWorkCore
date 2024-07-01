using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    internal class ApplicationDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("server=LAPTOP-DRA4PMTO;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);
            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.Entity<Book>().HasData(
                 new Book { BookID = 1, Title = "Spider without duty", ISBN = "123B12", Price = 10.99m, Publisher_Id=1 },
                 new Book { BookID = 2, Title = "Fortune of time", ISBN = "12123B12", Price = 11.99m, Publisher_Id=1 }
                );

            var bookList = new Book[]
            {
                new Book { BookID = 3, Title = "Fake sunday", ISBN = "77652", Price = 20.99m, Publisher_Id=2 },
                new Book { BookID = 4, Title = "Fortune jar", ISBN = "CC121B12", Price = 25.99m, Publisher_Id=3 },
                new Book { BookID = 5, Title = "cloudy forest", ISBN = "90392B33", Price = 40.99m, Publisher_Id=3 }
            };

            modelBuilder.Entity<Book>().HasData(bookList);


            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "pub 1 jimmy", Location = "Chicago" },
                new Publisher { Publisher_Id = 2, Name = "pub 2 john", Location = "New york" },
                new Publisher { Publisher_Id = 3, Name = "pub 3 Ben", Location = "Hawail" }
                );
        }
    }
}
