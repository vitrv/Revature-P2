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
    
    [HttpPost]
    public IActionResult ViewVehicleTypes(string decision)
    {
      if (decision == "adminportal") {
        return RedirectToAction("AdminPortal");
      }

      return View();
    }

    [HttpGet]
    public IActionResult ViewVehicles()
    {
      List<Vehicle> v = _session.GetVehicles();
      return View(v);
    }

    [HttpPost]
    public IActionResult ViewVehicles(string decision)
    {
      if (decision == "adminportal") {
        return RedirectToAction("AdminPortal");
      }
      
      return View();
    }

    [HttpGet]
    public IActionResult ViewLocations()
    {
      List<Location> l = _session.GetLocations();
      return View(l);
    }

    [HttpPost]
    public IActionResult ViewLocations(string decision)
    {
      if (decision == "adminportal") {
        return RedirectToAction("AdminPortal");
      }
      
      return View();
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
      if(ModelState.IsValid)
      {
        _session.UpdateVehicleType(vt);
      }
      return RedirectToAction("ViewVehicleTypes", "Admin");
    }

    [HttpGet]
    public IActionResult DeleteVehicleType(int vtid)
    {
      _session.DeleteVehicleType(vtid);
      return RedirectToAction("ViewVehicleTypes", "Admin");
    }

    [HttpGet]
    public IActionResult AddVehicleType()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddVehicleType(VehicleType vt)
    {
      if(ModelState.IsValid)
      {
        _session.RegisterVehicleType(vt);
      }
      return RedirectToAction("ViewVehicleTypes", "Admin");
    }

    [HttpGet]
    public IActionResult UpdateVehicle(int vid)
    {
      Vehicle v = _session.GetVehicle(vid);
      return View(v);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateVehicle(Vehicle v)
    {
      if(ModelState.IsValid)
        _session.UpdateVehicle(v);
      return RedirectToAction("ViewVehicles", "Admin");
    }

    [HttpGet]
    public IActionResult AddVehicle()
    {
      return View();
    }


    [HttpGet]
    public IActionResult DeleteVehicle(int vid)
    {
      _session.DeleteVehicle(vid);
      return RedirectToAction("ViewVehicles", "Admin");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddVehicle(Vehicle v)
    { 
      if(ModelState.IsValid)
         _session.RegisterVehicle(v);
      return RedirectToAction("ViewVehicles", "Admin");
    }

    [HttpGet]
    public IActionResult UpdateLocation(int lid)
    {
      Location l = _session.GetLocation(lid);
      return View(l);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateLocation(Location l)
    {
      if(ModelState.IsValid)
        _session.UpdateLocation(l);
      return RedirectToAction("ViewLocations", "Admin");
    }

    [HttpGet]
    public IActionResult DeleteLocation(int lid)
    {
      _session.DeleteLocation(lid);
      return RedirectToAction("ViewLocations", "Admin");
    }

    [HttpGet]
    public IActionResult AddLocation()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddLocation(Location l)
    {
      if(ModelState.IsValid)
        _session.RegisterLocation(l);
      return RedirectToAction("ViewLocations", "Admin");
    }

    [HttpGet]
    public IActionResult AdminPortal()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AdminPortal(string decision)
    {
      if(ModelState.IsValid) {
        if (decision == "viewlocations") {
          return RedirectToAction("ViewLocations");
        } else if (decision == "addlocation") {
          return RedirectToAction("AddLocation");
        } else if (decision == "viewvehicletypes") {
          return RedirectToAction("ViewVehicleTypes");
        } else if (decision == "addvehicletype") {
          return RedirectToAction("AddVehicleType");
        } else if (decision == "viewvehicles") {
          return RedirectToAction("ViewVehicles");
        } else if (decision == "addvehicle") {
          return RedirectToAction("AddVehicle");
        } else if (decision == "logout") {
          return RedirectToAction("Index", "Home");
        } 
      }
      
      return View();  
    }
  }
}
