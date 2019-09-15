using System;
using System.Collections.Generic;
using Acedrive.Client.Models;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers {
  public class RentalController : Controller {
    Session _session = SessionHandler.Instance();

    // GET: /Rental/RentalPeriodSelection
    [HttpGet]
    public IActionResult RentalPeriodSelection()
    {
      //display a view for entering the Rental Start & End Date for User
        RentalPeriodViewModel userrental = new RentalPeriodViewModel();
        TempData["Start"] = userrental.StartDate;
        TempData["End"] = userrental.EndDate;
        return View();
    }

    // POST: /Rental/RentalPeriodSelection
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RentalPeriodSelection(DateTime startdate, DateTime enddate)
    {
      if (ModelState.IsValid) {
        //add code to save selected location to db
        string start = startdate.ToString("D");
        string end = enddate.ToString("D");
      
        _session.AddTime(start, end);
        //return Content($"You selected the rent of period of: {start} - {end}.\nIs this correct?");
        return RedirectToAction("LocationSelection", "Location");
      }
      return View();
    }
  }    
}