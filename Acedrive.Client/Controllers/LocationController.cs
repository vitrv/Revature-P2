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
      //retrieve list of all car types in db with
      List<Location> locations = _session.GetLocations();
        return View(locations);
    }   
  }    
}