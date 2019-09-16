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
    public IActionResult ViewVehicles()
    {
      List<Vehicle> v = _session.GetVehicles();
      return View(v);
    }
    public IActionResult ViewLocations()
    {
      List<Location> l = _session.GetLocations();
      return View(l);
    }
    [HttpGet]
    public IActionResult UpdateVehicleType(int vtid)
    {
      VehicleType vt = _session.GetVehicleType(vtid);
      return View(vt);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateVehicleType(VehicleType vt)
    {
      _session.UpdateVehicleType(vt);
      return RedirectToAction("ViewVehicleTypes", "Admin");
    }
    [HttpDelete]
    public IActionResult DeleteVehicleType()
    {

      return View();
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
