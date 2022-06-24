using System;
using System.Collections;
using System.Collections.Generic;

namespace Library.Data
{
    public enum Genre
    {
        War,
        Romance,
        Criminal
    }

    public enum Currency
    {
        USD,
        PLN,
        EUR
    } 
        
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public Currency Currency { get; set; }
        public User UserRenting { get; set; }
        public DateTime RentingDate { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public ICollection<Book> RentedBooks { get; set;}
        public bool IsAdmin { get; set; }
        public Genre WatchedGenre { get; set; }
        public ICollection<Book> WatchList { get; set; }

        public override string ToString()
        {
            return Login ?? "";
        }
    }

    public class HistoryBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public Currency Currency { get; set; }
        public DateTime RentedDate { get; set; }
    }

    public class User_History_book
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public HistoryBook HistoryBook { get; set; }
    }
}