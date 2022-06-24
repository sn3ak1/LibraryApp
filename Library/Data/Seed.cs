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
            
            context.Users.Add(new User() {Name = "admin", SurName = "admin", IsAdmin = true, Login = "admin", PasswordHash = UserController.Encrypt("admin")});

            context.Books.Add(new Book()
            {
                Title = "book1", Author = "auth1", Currency = Currency.USD, Genre = Genre.Criminal, Price = 10,
                PageCount = 100, RentingDate = DateTime.Today
            });
            
            context.Books.Add(new Book()
            {
                Title = "book2", Author = "auth1", Currency = Currency.PLN, Genre = Genre.Romance, Price = 15,
                PageCount = 100, RentingDate = DateTime.Today
            });
            
            context.Books.Add(new Book()
            {
                Title = "book3", Author = "auth2", Currency = Currency.USD, Genre = Genre.War, Price = 12,
                PageCount = 100, RentingDate = DateTime.Today
            });

            context.SaveChanges();
        }
    }
}