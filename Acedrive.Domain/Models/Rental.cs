using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Acedrive.Domain.Models
{
  public partial class Rental
  {
    [Key]
    public int RentalId { get; set; }
    //[DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    //[DataType(DataType.Date)]
    public DateTime EndDate {get; set; }
    public int UserRefId { get; set; }
    public User UId { get; set; }
    public int LocationRefId { get; set; }
    public Location LocId { get; set; }
    public int VehicleRefId { get; set; }
    public Vehicle VehId { get; set; }
    // [MaxLength(1)]
    public bool VehicleStatus { get; set; }

    [DataType(DataType.Currency)]
    public decimal RentalCost { get; set; }
    public ICollection<Payment> Payments { get; set; }

    public string ConvertToMonthName(int month) {
      return DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
    }

    public int DaysForMonth(int month) {
      int currentyear = DateTime.Now.Year;
      return DateTime.DaysInMonth(currentyear, month);
    }
  }
}