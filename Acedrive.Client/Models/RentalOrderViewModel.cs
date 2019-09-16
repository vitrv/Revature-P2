using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Acedrive.Domain.Models;

namespace Acedrive.Client.Models {
  public class RentalOrderViewModel
  {
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public string StoreLocation { get; set; }
    public string VehicleType { get; set; }
    public string VehicleTypeCostPerDay { get; set; }
    public string VehicleManufacturer { get; set; }
    public string VehicleModel { get; set; }
    public string VehicleYear { get; set; }
    public string PaymentAmount { get; set; }
    public void DisplayRentalPeriod(string startdate, string enddate) {
      StartDate = startdate;
      EndDate = enddate;
    }

    public void DisplayStoreLocation(Location location) {
      StoreLocation = $"{location.LocationAddress},\n{location.LocationCity}, {location.LocationState}, {location.LocationZipcode}";
    }

    public void DisplayRentalVehicleType(VehicleType vehicletype) {
      VehicleType = vehicletype.VehicleTypeName;
      VehicleTypeCostPerDay = $"${vehicletype.VehicleTypeCostPerDay.ToString()}";
    }

    public void DisplayRentalVehicle(Vehicle vehicle) {
      VehicleManufacturer = vehicle.Manufacturer;
      VehicleModel = vehicle.Model;
      VehicleYear = vehicle.Year.ToString();
    }
    public void DisplayRentalPayment(Payment payment) {
      PaymentAmount = $"${payment.PaymentAmount.ToString()}";
    }
  }
}