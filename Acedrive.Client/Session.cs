using System.Collections.Generic;
using Acedrive.Data;
using Acedrive.Domain;
using Acedrive.Domain.Models;

namespace Acedrive.Client
{
  public class SessionHandler
  {
    private static Session _instance { get; set; }
    public static Session Instance()
    {
      if (_instance is null)
      {
        _instance = new Session();
      }
      return _instance;
    }
  }
  public class Session
  {
    internal Session()
    {
      _data = new DataAccess();
    }
    User _user;
    Location _location;
    TimeRange _tr;

    DataAccess _data;

    public void RegisterUser()
    {

    }
    public void LoginUser()
    {

    }
    public void LogoutUser()
    {

    }
    public void SelectLocation()
    {

    }
    public void SelectTime()
    {

    }
    public List<Vehicle> SearchVehicles()
    {
      return null;
    }
    public void SelectVehicle()
    {

    }
    public Rental ViewRental()
    {
      return null;
    }
    public Rental ConfirmRental()
    {
      return null;
    }
    public void RegisterVehicleType()
    {
      Domain.Models.VehicleType vt = new Domain.Models.VehicleType();

    }


  }
}