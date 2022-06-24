using System;
using System.Linq;
using System.Security.Cryptography;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data;

namespace Library.Core
{
    public class UserController
    {

        private static User _loggedAs;

        public static User LoggedAs
        {
            get
            {
                if (_loggedAs == null) return null;
                using var context = new Context();
                return context.Users
                    .Include(x=>x.RentedBooks)
                    // .Include(x=>x.RentingHistory).AsNoTracking()
                    .Include(x=>x.WatchList)
                    .FirstOrDefault(x=>x.Id == _loggedAs.Id);
            }
            set => _loggedAs = value;
        }

        public static bool AddUser(string login, string password, string name, string surName)
        {
            using var context = new Context();
            context.Database.EnsureCreated();
            if (context.Users.FirstOrDefault(x => x.Login == login) != null) return false;
            context.Users.Add(new User(){Login = login, PasswordHash = Encrypt(password), Name = name, SurName = surName});
            context.SaveChanges();
            return true;
        }

        public static bool Login(string name, string password)
        {
            using var context = new Context();
            var user = context.Users.AsNoTracking().FirstOrDefault(x=>x.Name == name);
            if (user == null) return false;
            var verified = CheckHash(password, user?.PasswordHash);
            if (verified)
                LoggedAs = user;
            return verified;
        }

        public static void Logout()
        {
            LoggedAs = null;
        }

        public static void DeleteUser(User user)
        {
            using var context = new Context();
            context.Users.Attach(user);
            context.Users.Remove(user);
            context.SaveChanges();
        }
        
        public static void EditUser(User user)
        {
            using var context = new Context();
            context.Users.Update(user);
            context.SaveChanges();
        }

        public static User[] GetUsers()
        {
            using var context = new Context();
            return context.Users
                .Include(x=>x.RentedBooks)
                // .Include(x=>x.RentingHistory)
                .Include(x=>x.WatchList)
                .ToArray();
        }

        public static string Encrypt(string password)
        {   
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            var hash = pbkdf2.GetBytes(20);
            
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            
            var savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static bool CheckHash(string password, string savedPasswordHash)
        {
            var hashBytes = Convert.FromBase64String(savedPasswordHash);
            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            var hash = pbkdf2.GetBytes(20);
            for (var i=0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
    }
}