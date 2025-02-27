﻿using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; } 
        public DbSet<Fluent_BookDetail> BookDetail_fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_BookAuthorMap> Fluent_BookAuthorMaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
           // options.UseSqlServer("server=LAPTOP-DRA4PMTO;Database=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
             //   .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

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
