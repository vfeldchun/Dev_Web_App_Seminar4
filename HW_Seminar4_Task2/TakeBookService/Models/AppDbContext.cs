using Microsoft.EntityFrameworkCore;

namespace TakeBookService.Models
{
    public partial class AppDbContext : DbContext
    {
        private string _connectionString;
        public DbSet<ClientBook> ClientBooks { get; set; }

        public AppDbContext() { }

        public AppDbContext(string connectionString) => _connectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseNpgsql(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientBook>(entity =>
            {
                entity.HasKey(e => e.BookId).HasName("book_pkey");
                entity.ToTable("client_book");
                entity.Property(e => e.ClientId).HasColumnName("client_id");
                entity.Property(e => e.BookId).HasColumnName("book_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
