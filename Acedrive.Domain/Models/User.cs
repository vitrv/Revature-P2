namespace Acedrive.Domain.Models
{
  public partial class User
  {
    public int UserID { get; set; }
    public string Username { get; set; }
    public string UserPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public string State { get; set; }
    public string Zipcode { get; set; }

    public string UserDL { get; set; }

    public string UserDOB { get; set; }

    public string UserEmail { get; set; }
    public string UserPhoneNumber {get; set; }

    public string UserInsurance { get; set; }


  }
}