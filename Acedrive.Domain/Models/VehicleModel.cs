namespace Acedrive.Domain.Models
{
  public partial class VehicleModel
  {
   public int VehicleModelID { get; set; } 
   public string Manufacturer {get; set;}
   public string Model {get; set;}

   public int Year {get; set;}

   public int GasCapacity {get; set;}

   public int FuelEfficiency {get; set; }



  }
}