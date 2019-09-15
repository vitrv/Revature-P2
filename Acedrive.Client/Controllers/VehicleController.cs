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
      //retrieve list of all car types in db with
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
        //return Content($"You ordered a {result.VehicleTypeName} which will be {result.VehicleTypeCostPerDay} per Day. Is this correct?");
        return RedirectToAction("VehicleSelection", new { vtid = result.VehicleTypeId, vtype = result.VehicleTypeName});
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
        _session.AddVehicle(result);
        var vt = _session.SelectedVehicleType(result.VehicleTypeRefId);
        var loc = _session.ReadLocation();
        var stime = _session.ReadTime("start");
        var etime = _session.ReadTime("end");
        return Content($"You ordered a {vt.VehicleTypeName} which will be {vt.VehicleTypeCostPerDay} per Day. " +
                        $"Your selected vehicle is a {result.Year} {result.Manufacturer} {result.Model} from " +
                        $"{loc.LocationAddress}, {loc.LocationCity}, {loc.LocationState}, {loc.LocationZipcode} for " +
                        $"the time period of: {stime} - {etime}. Is this correct?");
        //return RedirectToAction("EnterPaymentInfo", "Payment");
      }
      return View();
    }
  }   
}