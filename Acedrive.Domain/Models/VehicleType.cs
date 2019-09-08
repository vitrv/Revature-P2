using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acedrive.Domain.Models
{
  public class VehicleType
  {
    [Key]
    public int VehicleTypeId { get; set; }
    public string VehicleTypeName { get; set; }
    [DataType(DataType.Currency)]
    public decimal VehicleTypeCostPerDay { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }
  }
}