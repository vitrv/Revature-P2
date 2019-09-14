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
    
    public void AddUser(User u)
    {

    }
    public void AddVehicleType(VehicleType vt)
    {
      
    }

    internal void SavetoVehicles(Vehicle v) {
      _db.Add(v);
      _db.SaveChanges();
    }

    internal void SavetoVehicleTypes(VehicleType vt) {
      _db.Add(vt);
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

    internal Vehicle VehicleSelector(int id) {
      return _db.Vehicles.FirstOrDefault(v => v.VehicleId == id);
    }

    internal VehicleType VehicleTypeSelector(int id) {
      return _db.VehicleTypes.FirstOrDefault(vt => vt.VehicleTypeId == id);
    }
  }
}