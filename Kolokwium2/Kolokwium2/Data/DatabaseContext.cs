using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Data;

public class DatabaseContext : DbContext
{
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarRental> CarRentals { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Model> Models { get; set; }
    
     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Car>().HasData(new List<Car>
            {
                new Car {
                    ID = 1,
                    VIN = "aaaa",
                    Name = "car1",
                    Seats = 2,
                    PricePerDay = 1000,
                    ModelID = 1,
                    ColorID = 1
                }
            });
        modelBuilder.Entity<CarRental>().HasData(new List<CarRental>
        {
            new CarRental {
                ID = 1,
                ClientID = 1,
                CarID = 1,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(5),
                TotalPrice = 900,
                Discount = 10
            }
        });
        
        modelBuilder.Entity<Client>().HasData(new List<Client>
        {
            new Client {
                ID = 1,
                FirstName = "Adam",
                LastName = "Ryszka",
                Address = "ul. Wilcza 8c/12"
            }
        });
        modelBuilder.Entity<Color>().HasData(new List<Color>
        {
            new Color {
                ID = 1,
                Name = "Blue"
            }
        });
        modelBuilder.Entity<Model>().HasData(new List<Model>
        {
            new Model {
                ID = 1,
                Name = "Model1"
            }
        });
    }
}