using System;
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
    DateTime _start;
    DateTime _end;
    string _startdateformat;
    string _enddateformat;
    public void RegisterUser()
    {

    }

    public void LoginUser(User u)
    {
      _user = u;
    }

    public void LogoutUser()
    {
      _user = null;
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
    public void SelectTime(DateTime s, DateTime e)
    {
      _start = s;
      _end = e;
    }

    internal void AddTime(string start, string end) {
      _startdateformat = start;
      _enddateformat = end;
    }
    
    internal string ReadTime(string timeselect) {
      if (timeselect == "start") {  
        return _startdateformat;
      } else {
        return _enddateformat;
      }
    }

    public List<Vehicle> SearchVehicles()
    {
      return null;
    }

    public void SelectVehicle(Vehicle v)
    {
      _vehicle = v;
    }

    public Rental ViewRental()
    {
      return null;
    }

    public Rental ConfirmRental()
    {
      return null;
    }

    public Payment GetRentalPayment()
    {
      TimeSpan rentalLength = new TimeSpan();
      try
      {
      rentalLength = _end - _start;
      }
      catch(OverflowException)
      {
        return null;
      }
      Payment result = new Payment();
      result.PaymentDate = _start;
      result.PaymentAmount = ComputeCost(_user.IsInsured, rentalLength.Days, _vehicle.VehTypeId);
      return result;
    }
    private decimal ComputeCost(bool insured, int rentPeriod, VehicleType vehicleType)
    {
      decimal costFactor = vehicleType.VehicleTypeCostPerDay;
      decimal cost = costFactor * rentPeriod;
      if (!insured)
      {
        cost += 50M;
      }
      return cost;
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