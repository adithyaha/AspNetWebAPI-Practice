using Microsoft.EntityFrameworkCore;
using CarsAPI_EFSQLServer.Models;

namespace CarsAPI_EFSQLServer.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Cars");

                entity.Property(c => c.CarId).IsRequired();
                entity.Property(c => c.CarName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.Category).IsRequired().HasMaxLength(50);
                entity.Property(c => c.CarPrice).IsRequired().HasColumnType("decimal(18, 2)");
            });
        }
    }
}
