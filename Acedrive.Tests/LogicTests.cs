using Acedrive.Client;
using Microsoft.Extensions.Configuration;
using Acedrive.Domain.Models;
using Xunit;
using System;

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


      Payment p = s.GetRentalPayment();
      decimal result = p.PaymentAmount;

      Assert.Equal(result, 100M);


    }
  }
}