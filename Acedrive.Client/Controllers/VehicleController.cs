using System.Collections.Generic;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers
{
  public class VehicleController : Controller
  {
    Session _session = SessionHandler.Instance();

    // GET: /Vehicle/VehicleTypeSelction
    [HttpGet]
    public IActionResult VehicleTypeSelection()
    {
      List<VehicleType> vehicletypes = _session.GetVehicleTypes();
      return View(vehicletypes);
    }

    // POST: /Vehicle/VehicleTypeSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VehicleTypeSelection(int vtid)
    {
      if (ModelState.IsValid) {
        var result = _session.SelectedVehicleType(vtid);
        _session.AddVehicleType(result);
        return RedirectToAction("VehicleSelection", new { vtid = result.VehicleTypeId, vtype = result.VehicleTypeName});
      }

      return View();
    }

    // GET: /Vehicle/VehicleSelection
    [HttpGet]
    public IActionResult VehicleSelection(int vtid, string vtype) {
      List<Vehicle> vehicles = _session.GetVehicles(vtid);
      return View(vehicles);
    }

    // POST: /Vehicle/VehicleSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VehicleSelection(int vid)
    {
      if (ModelState.IsValid) {
        var result = _session.SelectedVehicle(vid);
        _session.AddVehicle(result);
        return RedirectToAction("DisplayRentalDetails", "Rental");
      }

      return View();
    }
  }   
}