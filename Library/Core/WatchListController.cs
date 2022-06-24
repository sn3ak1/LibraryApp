using System.Linq;
using Library.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Core
{
    public class WatchListController
    {
        public static string CheckWatchList()
        {
            var u = UserController.LoggedAs;
            var str = "";
            using var context = new Context();
            
            var books = context.WatchLists
                .Where(x => x.UserId == u.Id).Select(x=>x.Book);
            
            foreach (var book in books)
            {
                if (book.UserRenting == null)
                    str += book.Title + " written by " + book.Author + "\n";
            }
            
            if (str != "")
                return "There are new books available from your watchlist:\n" + str;
            return null;
        }
    }
}