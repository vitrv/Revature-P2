using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acedrive.Domain.Models
{
  public partial class Rental
  {
    [Key]
    public int RentalId { get; set; }
    [DataType(DataType.Date)]
    public int StartDate { get; set; }
    [DataType(DataType.Date)]
    public int EndDate {get; set; }
    public int UserRefId { get; set; }
    public User UId { get; set; }
    public int LocationRefId { get; set; }
    public Location LocId { get; set; }
    public int VehicleRefId { get; set; }
    public Vehicle VehId { get; set; }
    [MaxLength(1)]
    public string VehicleStatus { get; set; }

    public ICollection<Payment> Payments { get; set; }

  }
}