using System.Collections.Generic;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers
{
  public class AdminController : Controller
  {
    Session _session = SessionHandler.Instance();

        [HttpGet]
    public IActionResult ViewVehicleTypes()
    {
      List<VehicleType> vt = _session.GetVehicleTypes();
      return View(vt);
    }

    [HttpGet]
    public IActionResult AddVehicleType()
    {

      return View();
    }

    [HttpPost]
    public IActionResult AddVehicleType(VehicleType vt)
    {
      
      return View();
    }

    [HttpGet]
    public IActionResult AddVehicle()
    {

      return View();
    }

    [HttpPost]
    public IActionResult AddVehicle(Vehicle v)
    {
      
      return View();
    }
        [HttpGet]
    public IActionResult AddLocation()
    {

      return View();
    }

    [HttpPost]
    public IActionResult AddLocation(Location l)
    {
      
      return View();
    }
  
  
  
  }
}
