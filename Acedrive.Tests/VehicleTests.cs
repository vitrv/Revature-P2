using Acedrive.Client;
using Acedrive.Domain.Models;
using Xunit;

namespace Acedrive.Tests
{
  public class VehicleTests
  {
    [Fact]
    public void Vehicle_Is_Correct()
    {
      // Arrange
      string expectedvtypename = "Sedan";
      decimal expectedvtypeprice = 20M;

      // Act
      VehicleType vtype = new VehicleType { 
        VehicleTypeName = "Sedan", 
        VehicleTypeCostPerDay = 20M
      };
      string actualvtypename = vtype.VehicleTypeName;
      decimal actualvtypeprice = vtype.VehicleTypeCostPerDay;

      // Assert
      Assert.Equal(expectedvtypename, actualvtypename);
      Assert.Equal(expectedvtypeprice, actualvtypeprice);
    }
  }
}
