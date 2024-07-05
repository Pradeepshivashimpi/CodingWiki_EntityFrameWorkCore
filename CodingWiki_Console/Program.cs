// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

Console.WriteLine("Hello, World!");

//using(ApplicationDbContext context = new())
//{
//    context.Database.EnsureCreated();
//    if(context.Database.GetPendingMigrations().Count() > 0 )
//    {
//        context.Database.Migrate();
//    }
//}

//AddBooks();
// GetAllBooks();
//GetBook();
//UpdateBook();
//DeleteBook();



//void GetBook()
//{
//    using var context = new ApplicationDbContext();
//    var input = "Fortune jar";
//    var books = context.Books.Skip(0).Take(2);
//   // Console.WriteLine(books.Title + "-" + books.ISBN);
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + "-" + book.ISBN);
//    }

//    books = context.Books.Skip(4).Take(1);
//    // Console.WriteLine(books.Title + "-" + books.ISBN);
//    foreach (var book in books)
//    {
//        Console.WriteLine(book.Title + "-" + book.ISBN);
//    }
//}

//async void GetAllBooks()
//{
//    using var context = new ApplicationDbContext();
//    var books =await context.Books.ToListAsync();
   
//}

//async void AddBooks()
//{
//    Book book = new() { Title = "new ef core book", ISBN ="99999", Price = 10.93m, Publisher_Id=1 };
//    using var context = new ApplicationDbContext();
//    var books = await context.Books.AddAsync(book);
//    await context.SaveChangesAsync();
//}


//async void UpdateBook()
//{
//    try
//    {
//        using var context = new ApplicationDbContext();
//        var books = await context.Books.Where(u => u.Publisher_Id == 1).ToListAsync();
//        foreach (var book in books)
//        {
//            book.Price = 55m;
//        }
//        await context.SaveChangesAsync();
//    }
//    catch (Exception ex)
//    {
        
//    }

//}


//async void DeleteBook()
//{
//    using var context = new ApplicationDbContext();
//    var book = await context.Books.FindAsync(8);
//    context.Books.Remove(book);
//    await context.SaveChangesAsync();
//}