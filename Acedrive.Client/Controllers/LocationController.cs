using System.Collections.Generic;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers {
  public class LocationController : Controller {
    Session _session = SessionHandler.Instance();

    // GET: /Location/LocationSelction
    [HttpGet]
    public IActionResult LocationSelection()
    {
      //retrieve list of all locations in db with
      List<Location> locations = _session.GetLocations();
        return View(locations);
    }

    // POST: /Location/LocationSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult LocationSelection(int lid)
    {
      if (ModelState.IsValid) {
        //add code to save selected location to db
        
        var result = _session.SelectedLocation(lid);
        _session.AddLocation(result);
        //return Content($"You selected our location at {result.LocationAddress}, {result.LocationCity}, {result.LocationState}, {result.LocationZipcode}.\nIs this correct?");
        return RedirectToAction("VehicleTypeSelection", "Vehicle");
      }
      return View();
    }
  }    
}