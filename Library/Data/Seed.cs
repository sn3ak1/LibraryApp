using System;
using Library.Core;

namespace Library.Data
{
    public class Seed
    {
        public static void AddToDb()
        {
            using var context = new Context();
            context.Database.EnsureCreated();

            var u1 = new User() { Name = "aaa", SurName = "bbb"};

            context.Users.Add(new User() {Name = "admin", SurName = "admin", IsAdmin = true, Login = "admin", PasswordHash = UserController.Encrypt("admin")});

            context.Books.Add(new Book()
            {
                Title = "book1", Author = "auth1", Currency = Currency.USD, Genre = Genre.Criminal, Price = 10,
                PageCount = 100, RentingDate = DateTime.Today, UserRenting = u1
            });
            
            context.Books.Add(new Book()
            {
                Title = "book2", Author = "auth1", Currency = Currency.USD, Genre = Genre.Criminal, Price = 10,
                PageCount = 100, RentingDate = DateTime.Today, UserRenting = u1
            });
            
            context.Books.Add(new Book()
            {
                Title = "book3", Author = "auth1", Currency = Currency.USD, Genre = Genre.Criminal, Price = 10,
                PageCount = 100, RentingDate = DateTime.Today, UserRenting = u1
            });

            context.SaveChanges();
        }
    }
}