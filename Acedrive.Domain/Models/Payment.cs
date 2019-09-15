using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acedrive.Domain.Models
{
  public class Payment
  {
    [Key]
    public int PaymentId { get; set; }
    public int RentalRefId { get; set; }
    public Rental RentId { get; set; }
    //[DataType(DataType.Date)]
    public DateTime PaymentDate {get; set; }
    [DataType(DataType.Currency)]
    public decimal PaymentAmount { get; set; }
  }
}