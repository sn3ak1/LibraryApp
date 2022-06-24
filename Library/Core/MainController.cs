using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Core
{
    public class MainController
    {
        public static List<Book> GetBooks()
        {
            using var context = new Context();
            return context.Books.Include(x => x.UserRenting).ToList();
        }

        public static bool RentBook(Book book)
        {
            if(UserController.LoggedAs.RentedBooks.Count>=3 || book.UserRenting!=null) return false;
            
            using var context = new Context();
            // context.Attach(book);
            // book.UserRenting = UserController.LoggedAs;
            // book.RentingDate = DateTime.Today;
            //

            var u = UserController.LoggedAs;
            
            var b = context.Books.FirstOrDefault(x => x.Id == book.Id);
            b.UserRenting = u;
            b.RentingDate = DateTime.Today;

            // context.UserHistoryBooks.Add(new User_History_book()
            // {
            //     User = u, HistoryBook = new HistoryBook()
            //         {
            //             Title = book.Title, Author = book.Author, Genre = book.Genre, Currency = book.Currency,
            //             Price = book.Price, PageCount = book.PageCount
            //         }
            // });

            // UserController.LoggedAs.RentingHistory.Add(book);
            // context.Users.Update(UserController.LoggedAs);
            // context.Books.Update(book);
            context.SaveChanges();
            return true;
        }

        public static void DeleteBook(Book book)
        {
            using var context = new Context();
            context.Books.Attach(book);
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public static void AddBook(Book book)
        {
            using var context = new Context();
            context.Database.EnsureCreated();
            context.Books.Add(book);
            context.SaveChanges();
        }
        
        public static void EditBook(Book book)
        {
            using var context = new Context();
            context.Books.Attach(book);
            context.Books.Update(book);
            context.SaveChanges();
        }

        public static void ReturnBook(Book book)
        {
            using var context = new Context();
            var b = context.Books.FirstOrDefault(x => x.Id == book.Id);
            var u = context.Users.FirstOrDefault(x=>x.Id == book.UserRenting.Id);
            u!.RentedBooks.Remove(b);
            b!.UserRenting = null;
            context.SaveChanges();
        }

        public static HistoryBook[] GetUserHistory(User user)
        {
            using var context = new Context();
            return context.UserHistoryBooks
                .Where(x => x.User.Id == user.Id)
                .Select(x => x.HistoryBook).ToArray();
        }
    }
}