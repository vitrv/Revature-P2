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
    VehicleType _vehicletype;
    DateTime _start;
    DateTime _end;
    Rental _rental;
    string _startdateformat;
    string _enddateformat;
    string _paymentdateformat;
    decimal _payment;
    internal void AddLocation(Location location)
    {
      _location = location;
    }

    internal void UpdateVehicleType(VehicleType vt)
    {
      _data.UpdateVehicleType(vt);
    }

    internal Location ReadLocation()
    {
      return _location;
    }

    internal void DeleteVehicleType(int vtid)
    {
      _data.DeleteVehicleType(vtid);
    }

    internal void AddVehicleType(VehicleType vehicletype)
    {
      _vehicletype = vehicletype;
    }

    internal VehicleType ReadVehicleType()
    {
      return _vehicletype;
    }

    internal void AddVehicle(Vehicle vehicle)
    {
      _vehicle = vehicle;
    }

    internal Vehicle ReadVehicle()
    {
      return _vehicle;
    }

    internal Vehicle GetVehicle(int vid)
    {
      return _data.VehicleSelector(vid);
    }

    internal void AddTime(string start, string end) {
      _startdateformat = start;
      _enddateformat = end;
    }

    internal void UpdateVehicle(Vehicle v)
    {
      _data.UpdateVehicle(v);
    }

    internal string ReadTime(string timeselect) {
      if (timeselect == "start") {  
        return _startdateformat;
      } else if (timeselect == "end") {
        return _enddateformat;
      } else if (timeselect == "payment") {
        return _paymentdateformat;
      } else {
        return null;
      }
    }

    internal void DeleteVehicle(int vid)
    {
      _data.DeleteVehicle(vid);
    }

    internal void RegisterVehicle(Vehicle v)
    {
      _data.RegisterVehicle(v);
    }

    internal void AddRental(Rental rental)
    {
      _rental = rental;
    }

    internal Location GetLocation(int lid)
    {
      return _data.LocationSelector(lid);
    }

    internal void UpdateLocation(Location l)
    {
      _data.UpdateLocation(l);
    }

    internal Rental ReadRental()
    {
      return _rental;
    }
    internal void AddPaymentDate(string paymentdate)
    {
      _paymentdateformat = paymentdate;
    }

    internal decimal ReadPayment()
    {
      return _payment;
    }
    
    internal void DeleteLocation(int lid)
    {
      _data.DeleteLocation(lid);
    }

    public Rental ConfirmRental()
    {
      return _rental;
    }

    internal List<Vehicle> GetVehicles(int id)
    {
      return _data.GetAllVehicles(id);
    }

    internal void RegisterLocation(Location l)
    {
      _data.RegisterLocation(l);
    }

    internal List<VehicleType> GetVehicleTypes()
    {
      return _data.GetAllVehicleTypes();
    }
    internal VehicleType GetVehicleType(int vtid)
    {
      return _data.VehicleTypeSelector(vtid);
    }

    internal List<Location> GetLocations()
    {
      return _data.GetAllLocations();
    }

    internal bool ValidateUser(string email, string password) {
      bool usercheck = _data.ValidateUserEmail(email) && _data.ValidateUserPassword(password);
      return usercheck;
    }

    internal void SaveNewUser(User u) {
      _data.SavetoUsers(u);
    }

    internal void SaveNewRental(Rental r) {
      _data.SavetoRentals(r);
    }

    internal void SavePayment(Payment p) {
      _data.SavetoPayments(p);
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

    internal void GetUserInfo(string email, string password) {
      _user = _data.FindUser(email, password);
      _paymentdateformat = _data.FindUserPayment(email, password).PaymentDate.ToString("D");
      _startdateformat = _data.FindUserRental(email, password).StartDate.ToString("D");
      _enddateformat = _data.FindUserRental(email, password).EndDate.ToString("D");
      _location = _data.FindUserLocation(email, password);
      _vehicle = _data.FindUserVehicle(email, password);
      _payment = _data.FindUserPayment(email, password).PaymentAmount;
    }

    //Laura's Methods
    internal void RegisterUser(User u)
    {
      _user = u;
    }

    internal User ReadUser() {
      return _user;
    }

    public void LoginUser(User u) {
      _user = u;
    }

    public void SelectVehicle(Vehicle v)
    {
      _vehicle = v;
    }
    
    public void RegisterVehicleType(VehicleType vt)
    {
      _data.RegisterVehicleType(vt);
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
      _payment = result.PaymentAmount;
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
    
    public void SelectTime(DateTime s, DateTime e)
    {
      _start = s;
      _end = e;
    }

    internal List<Vehicle> GetVehicles()
    {
      return _data.GetAllVehicles();
    }  
    internal DateTime ReadStartDate() {
      return _start;
    }

    internal DateTime ReadEndDate() {
      return _end;
    }
  }
}