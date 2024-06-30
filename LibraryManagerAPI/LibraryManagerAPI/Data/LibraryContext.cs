using Microsoft.EntityFrameworkCore;
using LibraryManagerAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace LibraryManagerAPI.Data
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Book> Library { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Library");
                entity.Property(b => b.Id).IsRequired();
                entity.Property(b => b.Title).IsRequired().HasMaxLength(50);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(50);
                entity.Property(b => b.Publisher).HasMaxLength(50);
                entity.Property(b => b.PublishedDate);

            });
        }

    }
}
