using Microsoft.EntityFrameworkCore;
using Entities.Concrete;
using Core.Entities.Concrete;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DataAccess.Concrete.EntityFramework
{
    public class CarValueContext : DbContext
    {
        // Burada local veri tabanı bağlantısını sağlayacağız
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=CarValueDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarRentalDB;Trusted_Connection=True;",



            //    sqlOptions => sqlOptions.EnableRetryOnFailure(
            //    maxRetryCount: 5, // Yeniden deneme sayısı
            //    maxRetryDelay: TimeSpan.FromSeconds(10), // Her deneme arasındaki bekleme süresi
            //    errorNumbersToAdd: null)
            //                );

            //optionsBuilder.UseSqlServer
            //    (@"Server=(localdb)\MSSQLLocalDB;Database=RentACar;Trusted_Connection=true");

            //optionsBuilder.UseSqlServer("Server=localhost;Database=CarRentalDB;Integrated Security=True;Trusted_Connection=true;");
            optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = CarRentalDB; Integrated Security = True; Trust Server Certificate = True\r\n");



            //@"Server=(localdb)\mssqllocaldb;Database=RentalDb;Trusted_Connection=true"
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //modelBuilder.Entity<Car>()
            //    .Property(c => c.DailyPrice)
            //    .HasPrecision(18, 2); // 18 basamak ve 2 ondalık basamak

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}

