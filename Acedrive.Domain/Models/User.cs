using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Acedrive.Domain.Models
{
  public partial class User
  {
    [Key]
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserAddress { get; set; }
    public string UserCity { get; set; }
    [MaxLength(2)]
    public string UserState { get; set; }
    [MaxLength(10)]
    public string UserZipcode { get; set; }
    public string UserDriverLicense { get; set; }

    //[DataType(DataType.Date)]
    public DateTime UserDOB { get; set; }
    [EmailAddress]
    public string UserEmail { get; set; }
    [Phone]
    public string UserPhoneNumber {get; set; }
    public bool IsInsured { get; set; }

    public ICollection<Rental> Rentals { get; set; }



  }
}