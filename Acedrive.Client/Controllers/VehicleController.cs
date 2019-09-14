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
      List<VehicleType> vehicletypes = _session.GetAllVehicleTypes();
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
        return Content($"You ordered a {result.VehicleTypeName} which will be {result.VehicleTypeCostPerDay} per Day. Is this correct?");
      }
      return View();
    }
  }   
}