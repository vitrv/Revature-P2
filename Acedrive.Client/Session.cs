using System.Collections.Generic;
using Acedrive.Data;
using Acedrive.Domain;
using Acedrive.Domain.Models;

namespace Acedrive.Client
{
  public static class SessionHandler
  {
    private static Session _instance { get; set; }
    public static Session Instance()
    {
      if (_instance is null)
      {
        return null;
      }
      return _instance;
    }
  public static void InstanceInit(string secret)
    {
      if (_instance is null)
      {
        _instance = new Session(secret);
      }
    }
    
  }
  public class Session
  {
    DataAccess _data;
    internal Session(string secret)
    {
      _data = new DataAccess(secret);
    }
    User _user;
    Location _location;
    Vehicle _vehicle;
    Vehicle _vehicleype;
    public void RegisterUser()
    {

    }

    public void LoginUser()
    {

    }

    public void LogoutUser()
    {

    }

    internal void AddLocation(Location location)
    {
      _location = location;
    }

    internal Location ReadLocation()
    {
      return _location;
    }

    internal void AddVehicle(Vehicle vehicle)
    {
      _vehicle = vehicle;
    }

    internal Vehicle ReadVehicle()
    {
      return _vehicle;
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

    internal void SaveV(Vehicle v) {
      _data.SavetoVehicles(v);
    }

    internal void SaveVT(VehicleType vt) {
      _data.SavetoVehicleTypes(vt);
    }

    internal List<Vehicle> GetVehicles(int id)
    {
      return _data.GetAllVehicles(id);
    }

    internal List<VehicleType> GetVehicleTypes()
    {
      return _data.GetAllVehicleTypes();
    }

    internal List<Location> GetLocations()
    {
      return _data.GetAllLocations();
    }

    internal Vehicle SelectedVehicle(int id) {
      return _data.VehicleSelector(id);
    }

    internal VehicleType SelectedVehicleType(int id) {
      return _data.VehicleTypeSelector(id);
    }

    internal Location SelectedLocation(int id) {
      return _data.LocationSelector(id);
    }
  }
}