using System;
using System.Collections.Generic;
using System.Linq;
using Acedrive.Client.Models;
using Acedrive.Data;
using Acedrive.Domain.Models;
using Microsoft.Extensions.Options;

namespace Acedrive.Client
{
  public class DataAccess
  {
    AcedriveDbContext _db;
    public DataAccess(string secret)
    {      
      _db = new AcedriveDbContext(secret);
    }
    
    public void AddVehicleType(VehicleType vt)
    {
      
    }

    internal bool ValidateUserEmail(string email) {
      bool emailcheck = _db.Users.Select(u => u.UserEmail).Contains(email);
      return emailcheck;
    }

    internal bool ValidateUserPassword(string password) {
      bool emailcheck = _db.Users.Select(u => u.UserPassword).Contains(password);
      return emailcheck;
    }

    internal void SavetoUsers(User u) {
      _db.Users.Add(u);
      _db.SaveChanges();
    }

    internal void SavetoRentals(Rental r) {
      _db.Rentals.Add(r);
      _db.SaveChanges();
    }

    internal void SavetoPayments(Payment p) {
      _db.Payments.Add(p);
      _db.SaveChanges();
    }

    internal User FindUser(string email, string password)
    {
      List<User> users = _db.Users.ToList();
      User returninguser = users.Where(u => u.UserEmail == email).Where(u => u.UserPassword == password).SingleOrDefault();
      return returninguser;
    }
    
    internal Rental FindUserRental(string email, string password)
    {
      User u = FindUser(email, password);
      List<Rental> rentals = _db.Rentals.ToList();
      Rental userrental = rentals.Where(r => r.UserRefId == u.UserId).LastOrDefault();
      return userrental;
    }

    internal Location FindUserLocation(string email, string password)
    {
      User u = FindUser(email, password);
      Rental r = FindUserRental(email, password);
      List<Location> locations = _db.Locations.ToList();
      Location userlocation = locations.Where(l => l.LocationId == r.LocationRefId).SingleOrDefault();
      return userlocation;
    }

    internal Vehicle FindUserVehicle(string email, string password)
    {
      User u = FindUser(email, password);
      Rental r = FindUserRental(email, password);
      List<Vehicle> vehicles = _db.Vehicles.ToList();
      Vehicle uservehicle = vehicles.Where(v => v.VehicleId == r.VehicleRefId).SingleOrDefault();
      return uservehicle;
    }

    internal Payment FindUserPayment(string email, string password)
    {
      User u = FindUser(email, password);
      Rental r = FindUserRental(email, password);
      List<Payment> payments = _db.Payments.ToList();
      Payment userpayment = payments.Where(p => p.RentalRefId == r.RentalId).SingleOrDefault();
      return userpayment;
    }

    internal List<Vehicle> GetAllVehicles(int id)
    {
      return _db.Vehicles.Where(v => v.VehicleTypeRefId == id).ToList();
    }
    
    internal List<VehicleType> GetAllVehicleTypes()
    {
      return _db.VehicleTypes.ToList();
    }

    internal List<Location> GetAllLocations()
    {
      return _db.Locations.ToList();
    }

    internal Vehicle VehicleSelector(int id) {
      return _db.Vehicles.FirstOrDefault(v => v.VehicleId == id);
    }

    internal VehicleType VehicleTypeSelector(int id) {
      return _db.VehicleTypes.FirstOrDefault(vt => vt.VehicleTypeId == id);
    }

    internal Location LocationSelector(int id) {
      return _db.Locations.FirstOrDefault(l => l.LocationId == id);
    }
  }
}