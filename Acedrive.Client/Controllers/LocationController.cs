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
      List<Location> locations = _session.GetLocations();
        return View(locations);
    }

    // POST: /Location/LocationSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult LocationSelection(int lid)
    {
      if (ModelState.IsValid) {
        
        var result = _session.SelectedLocation(lid);
        _session.AddLocation(result);
        return RedirectToAction("VehicleTypeSelection", "Vehicle");
      }
      return View();
    }
  }    
}