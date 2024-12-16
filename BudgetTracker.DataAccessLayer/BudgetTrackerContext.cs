using BudgetTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.DataAccessLayer
{
    public class BudgetTrackerContext : DbContext
    {
        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// OnModelCreating metodu, veritabanı ilişkilerini ve konfigürasyonları ayarlamak için kullanılır
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Transaction - User: One-to-Many
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions) 
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction - Category: One-to-Many
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction - PaymentMethod: One-to-Many
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.PaymentMethod)
                .WithMany(p => p.Transactions) 
                .HasForeignKey(t => t.PaymentMethodId)
                .OnDelete(DeleteBehavior.Restrict);

            // Transaction - Amount: Precision ve Scale ayarı
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2); // 18 basamak, 2 ondalık basamak
        }
    }
}
