using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acedrive.Domain.Models
{
  public partial class Vehicle
  {
    [Key]
    public int VehicleId { get; set; }
    public int VehicleTypeRefId { get; set; } 
    public VehicleType VehTypeId {get; set; }
    public string Manufacturer {get; set;}
    public string Model {get; set;}
    public int Year {get; set;}
    public string VehicleLicensePlate { get; set; }

    //public int GasCapacity {get; set;}

    //public int FuelEfficiency {get; set; }
    
    public ICollection<Rental> Rentals { get; set; }



  }
}