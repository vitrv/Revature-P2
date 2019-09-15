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
    public IActionResult VehicleTypeSelection(Location loc)
    {
      //retrieve list of all car types in db with
      TempData["Location"] = loc;
      List<VehicleType> vehicletypes = _session.GetVehicleTypes();
        return View(vehicletypes);
    }

    // POST: /Vehicle/VehicleTypeSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VehicleTypeSelection(int vtid)
    {
      if (ModelState.IsValid) {
        //add code to save selected vehicle type to db
        
        var result = _session.SelectedVehicleType(vtid);
        var lid = TempData["LocationID"];
        //return Content($"You ordered a {result.VehicleTypeName} which will be {result.VehicleTypeCostPerDay} per Day. Is this correct?");
        return RedirectToAction("VehicleSelection", new { vtid = result.VehicleTypeId, vtype = result.VehicleTypeName });
      }
      return View();
    }

    // GET: /Vehicle/VehicleSelection
    [HttpGet]
    public IActionResult VehicleSelection(int vtid, string vtype) {
      //retrieve list of all cars in db with the associated vehicle type id
      List<Vehicle> vehicles = _session.GetVehicles(vtid);
        return View(vehicles);
    }

    // POST: /Vehicle/VehicleSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VehicleSelection(int vid)
    {
      if (ModelState.IsValid) {
        //add code to save selected vehicle to db
        
        var result = _session.SelectedVehicle(vid);
    
        var vt = _session.SelectedVehicleType(result.VehicleTypeRefId);
        var lid = (int) TempData["LocationID"];
        var l = _session.SelectedLocation(lid);
        return Content($"You ordered a {vt.VehicleTypeName} which will be {vt.VehicleTypeCostPerDay} per Day. " +
                        $"Your selected vehicle is a {result.Year} {result.Manufacturer} {result.Model} from " +
                        $"{l.LocationAddress}, {l.LocationCity}, {l.LocationState}, {l.LocationZipcode}. Is this correct?");
        //return RedirectToAction("EnterPaymentInfo", "Payment");
      }
      return View();
    }
  }   
}