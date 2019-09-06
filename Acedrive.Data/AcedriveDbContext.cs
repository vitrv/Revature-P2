using Microsoft.EntityFrameworkCore;
using Acedrive.Domain.Models;
namespace Acedrive.Data
{
  public class AcedriveDbContext: DbContext
  {
    public DbSet<Location>Locations {get; set;}
    public DbSet<Rental>Rentals {get;set;}
    public DbSet<Car>Cars {get;set;}
    public DbSet<User>Users {get;set;}
    public DbSet<VehicleType>VehicleTypes{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      if (!builder.IsConfigured)
      {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        builder.UseSqlServer("Server=tcp:lnc-sql.database.windows.net,1433;Initial Catalog=DriveDB;Persist Security Info=False;User ID=sqladmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      //all the builder.entity stuff will be created here
    }
    
  }
}