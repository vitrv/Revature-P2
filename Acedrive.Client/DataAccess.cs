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

    internal List<Vehicle> GetAllVehicles()
    {
      return _db.Vehicles.ToList();
    }
  }
    
}