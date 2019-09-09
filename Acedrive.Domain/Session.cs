using Acedrive.Domain.Models;

namespace Acedrive.Domain
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

    }
    User _user;
    Location _location;
    TimeRange _tr;

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

  }
}