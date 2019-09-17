using System;
using System.Collections.Generic;
using System.Linq;
using Acedrive.Client.Models;
using Acedrive.Data;
using Acedrive.Domain.Models;
using Microsoft.EntityFrameworkCore;
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
    
    internal void SavetoUsers(User u) {
      _db.Users.Add(u);
      _db.SaveChanges();
    }

    internal void SavetoRentals(Rental r) {
      _db.Rentals.Add(r);
      _db.SaveChanges();
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

    internal void UpdateVehicleType(VehicleType vt)
    {
     
      VehicleType vt2 = _db.VehicleTypes.FirstOrDefault(v => v.VehicleTypeId == vt.VehicleTypeId);
      vt2.VehicleTypeName = vt.VehicleTypeName;
      vt2.VehicleTypeCostPerDay = vt.VehicleTypeCostPerDay;
      _db.SaveChanges();
    }

    internal void DeleteVehicleType(int vtid)
    {
      VehicleType vt2 = _db.VehicleTypes.FirstOrDefault(v => v.VehicleTypeId == vtid);
      _db.VehicleTypes.Remove(vt2);
      _db.SaveChanges();
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

    internal void UpdateVehicle(Vehicle v)
    {
      Vehicle v2 = _db.Vehicles.FirstOrDefault(x => x.VehicleId == v.VehicleId);
      v2.Manufacturer = v.Manufacturer;
      v2.Model = v.Model;
      v2.VehicleLicensePlate = v.VehicleLicensePlate;
      v2.Year = v.Year;
      v2.VehicleTypeRefId = v.VehicleTypeRefId;
      _db.SaveChanges();
    }

    internal List<Vehicle> GetAllVehicles()
    {
      return _db.Vehicles.ToList();
    }

    internal void DeleteVehicle(int vid)
    {
      Vehicle v2 = _db.Vehicles.FirstOrDefault(v => v.VehicleId == vid);
      _db.Vehicles.Remove(v2);
      _db.SaveChanges();
    }

    internal void RegisterVehicle(Vehicle v)
    {
      VehicleType vt = VehicleTypeSelector(v.VehicleTypeRefId);
      v.VehTypeId = vt;
      _db.Vehicles.Add(v);
      _db.SaveChanges();
    }

    internal void RegisterVehicleType(VehicleType vt)
    {
      _db.VehicleTypes.Add(vt);
      _db.SaveChanges();
    }

    internal void UpdateLocation(Location l)
    {
      Location l2 = _db.Locations.FirstOrDefault(x => x.LocationId == l.LocationId);
      l2.LocationAddress = l.LocationAddress;
      l2.LocationCity = l.LocationCity;
      l2.LocationState = l.LocationState;
      l2.LocationZipcode = l.LocationZipcode;
      _db.SaveChanges();
    }

    internal void DeleteLocation(int lid)
    {
      Location l2 = _db.Locations.FirstOrDefault(l => l.LocationId == lid);
      _db.Locations.Remove(l2);
      _db.SaveChanges();
    }

    internal void RegisterLocation(Location l)
    {
      _db.Locations.Add(l);
      _db.SaveChanges();
    }
  }
}