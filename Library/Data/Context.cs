using System.Windows.Forms.VisualStyles;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        
        public DbSet<HistoryBook> HistoryBooks { get; set; }
        
        public DbSet<User_History_book> UserHistoryBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                "server=sql11.freesqldatabase.com;database=sql11501735;user=sql11501735;password=dNSw5WXyM9");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.HasOne(d => d.UserRenting)
                    .WithMany(p => p.RentedBooks);
            });
            

        }
        
    }
}