using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Acedrive.Domain.Models;

namespace Acedrive.Client.Models {
  public class UserRentalHistoryViewModel
  {
    public string NameofUser { get; set; }
    public string PaymentDate { get; set; }
    public string AmountPaid { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string StoreLocation { get; set; }
    public string RentedVehicle { get; set; }

    public void DisplayNameofUser(string firstname) {
      NameofUser = firstname;
    }
    public void DisplayRentalDates(string startdate, string enddate, string paymentdate) {
      StartDate = startdate;
      EndDate = enddate;
      PaymentDate = paymentdate;
    }

    public void DisplayStoreLocation(Location location) {
      StoreLocation = $"{location.LocationAddress}, {location.LocationCity}, {location.LocationState}, {location.LocationZipcode}";
    }

    public void DisplayRentedVehicle(Vehicle vehicle) {
      RentedVehicle = $"{vehicle.Year} {vehicle.Manufacturer} {vehicle.Model}";
    }
    public void DisplayAmountPaid(decimal payment) {
      AmountPaid = $"${payment}";
    }
  }
}