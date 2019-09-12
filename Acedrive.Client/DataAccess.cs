using System;
using Acedrive.Client.Models;
using Acedrive.Data;
using Acedrive.Domain.Models;
using Microsoft.Extensions.Options;

namespace Acedrive.Client
{
  public class DataAccess
  {
    AcedriveDbContext _db;
    private readonly ConnectionString _cs;
    public DataAccess(IOptions<ConnectionString> ConnectionString)
    {      
      _cs = ConnectionString.Value ?? throw new ArgumentException(nameof(ConnectionString));
      _db = new AcedriveDbContext(_cs.Secret);
    }
    
    public void AddUser(User u)
    {

    }
    public void AddVehicleType(VehicleType vt)
    {
      
    }
  }
    
}