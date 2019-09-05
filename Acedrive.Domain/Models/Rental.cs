namespace Acedrive.Domain.Models
{
  public partial class Rental
  {
    public int RentalID { get; set; }

    public int StartDate { get; set; }
    public int EndDate {get; set; }

    public int Invoice {get ; set; }
  }
}