using Microsoft.EntityFrameworkCore;
using Acedrive.Domain.Models;
namespace Acedrive.Data
{
  public class AcedriveDbContext: DbContext
  {
    public DbSet<Location>Locations {get; set;}
    public DbSet<Vehicle>Vehicles { get; set; }
    public DbSet<Rental>Rentals {get;set;}
    public DbSet<Payment>Payments { get; set; }
    public DbSet<User>Users {get;set;}
    public DbSet<VehicleType>VehicleTypes{get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      if (!builder.IsConfigured)
      {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //builder.UseSqlServer("server=localhost;initial catalog=AceDriveDb;user id =sa; password=Password12345;");

        builder.UseSqlServer("Server=tcp:lnc-sql.database.windows.net,1433;Initial Catalog=DriveDB;Persist Security Info=False;User ID=sqladmin;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
      }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Vehicle>()
      .HasOne(v => v.VehTypeId)
      .WithMany(vt=> vt.Vehicles)
      .HasForeignKey(v=>v.VehicleTypeRefId);

      builder.Entity<Rental>()
      .HasOne(r => r.LocId)
      .WithMany(l =>l.Rentals)
      .HasForeignKey(r => r.LocationRefId);

      builder.Entity<Rental>()
      .HasOne(r => r.UId)
      .WithMany(u =>u.Rentals)
      .HasForeignKey(r => r.UserRefId);

      builder.Entity<Rental>()
      .HasOne(r => r.VehId)
      .WithMany(v =>v.Rentals)
      .HasForeignKey(r => r.VehicleRefId);

      builder.Entity<Payment>()
      .HasOne(p => p.RentId)
      .WithMany(r =>r.Payments)
      .HasForeignKey(p => p.RentalRefId);

      builder.Entity<User>()
      .Property(u => u.UserDOB)
      .HasColumnType("date");

      builder.Entity<Payment>()
      .Property(p => p.PaymentDate)
      .HasColumnType("date");

      builder.Entity<Rental>()
      .Property(r => r.StartDate)
      .HasColumnType("date");

      builder.Entity<Rental>()
      .Property(r => r.EndDate)
      .HasColumnType("date");


      




    }
    
  }
}