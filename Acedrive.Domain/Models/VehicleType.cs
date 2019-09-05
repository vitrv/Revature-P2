namespace Acedrive.Domain.Models
{
  public partial class VehicleType
  {
   public int VehicleTypeID { get; set; } 
   public string Manufacturer {get; set;}
   public string Model {get; set;}

   public int Year {get; set;}

   public int GasCapacity {get; set;}

   public int FuelEfficiency {get; set; }



  }
}