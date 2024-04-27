using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.WebAPI.Entities;

namespace MultiShop.Cargo.WebAPI.Context;

public class CargoContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=tcp:localhost,1433;Database=MultiShopCargoDb;User ID=SA;Password=levent123;Trusted_Connection=False;TrustServerCertificate=True;Encrypt=false;");  
    }

    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoOperation> CargoOperation { get; set; }
}