using Acedrive.Client;
using Microsoft.Extensions.Configuration;
using Acedrive.Domain.Models;
using Xunit;
using System;
using System.Globalization;

namespace Acedrive.Tests
{
  public class LogicTests
  {
    IConfiguration Configuration { get; set; }
    [Fact]
    public void TestSession()
    {
      var builder = new ConfigurationBuilder()
        .AddUserSecrets<LogicTests>();

      Configuration = builder.Build();
      string secret = Configuration["ConnectionString:Secret"];
      SessionHandler.InstanceInit(secret);
      Session s = SessionHandler.Instance();

      Assert.NotNull(secret);
      Assert.NotNull(s);
    }


    [Fact]
    public void TestCostCalculation()
    {
      var builder = new ConfigurationBuilder()
        .AddUserSecrets<LogicTests>();

      Configuration = builder.Build();
      SessionHandler.InstanceInit(Configuration["ConnectionString:Secret"]);
      Session s = SessionHandler.Instance();

      User u = new User();
      u.IsInsured = false;
      Vehicle v = new Vehicle();
      VehicleType vt = new VehicleType();
      vt.VehicleTypeCostPerDay = 5M;
      v.VehTypeId = vt;
      s.LoginUser(u);
      s.SelectVehicle(v);
      DateTime start = new DateTime(2019, 10, 1);
      DateTime end = new DateTime(2019, 10, 11);
      s.SelectTime(start, end);

      decimal expectedamount = 100M;
      Payment p = s.GetRentalPayment();
      decimal result = p.PaymentAmount;

      Assert.Equal(result, expectedamount);
    }

    [Fact]
    public void DateFormatCheck() {
      // Arrange
      string expecteddate = "Saturday, September 14, 2019";
      string expecteddate2 = "Sunday, September 15, 2019";
      string expectedmonth = "March";

      // Act
      DateTime testdate = new DateTime(2019, 9, 14);
      DateTime testmonth = new DateTime(2019, 3, 12);
      var actualdate = testdate.ToString("D");
      var actualdate2 = DateTime.Now.ToString("D");
      var actualmonth = DateTimeFormatInfo.CurrentInfo.GetMonthName(3);

    // Assert
    Assert.Equal(expecteddate, actualdate);
    Assert.Equal(expecteddate2, actualdate2);
    Assert.Equal(expectedmonth, actualmonth);
    }

  }
}