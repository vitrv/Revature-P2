using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acedrive.Domain.Models
{
  public partial class Location
  {
    [Key]
    public int LocationId { get; set; }
    public string LocationAddress {get; set;}
    public string LocationCity { get; set; }
    public string LocationState { get; set; }
    public string LocationZipcode { get; set; }
    public ICollection<Rental> Rentals { get; set; }
  }
}