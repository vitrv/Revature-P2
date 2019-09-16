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
        RentalPeriodViewModel rentalperiod = new RentalPeriodViewModel();
        TempData["Start"] = rentalperiod.StartDate;
        TempData["End"] = rentalperiod.EndDate;
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
        _session.SelectTime(startdate, enddate);
        //return Content($"You selected the rent of period of: {start} - {end}.\nIs this correct?");
        return RedirectToAction("LocationSelection", "Location");
      }
      return View();
    }

    // GET: /Rental/DisplayRentalDetails
    [HttpGet]
    public IActionResult DisplayRentalDetails()
    {
      //display a view for showing the details of rental to User
      RentalOrderViewModel rentalparts = new RentalOrderViewModel();
      rentalparts.DisplayRentalPeriod(_session.ReadTime("start"), _session.ReadTime("end"));
      rentalparts.DisplayStoreLocation(_session.ReadLocation());
      rentalparts.DisplayRentalVehicleType(_session.ReadVehicleType());
      rentalparts.DisplayRentalVehicle(_session.ReadVehicle());
      return View(rentalparts);
    }

    // POST: /Rental/DisplayRentalDetails
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DisplayRentalDetails(bool rentalclear)
    {
      if (ModelState.IsValid) {
        //add code to save the data to Rentals Table
        //return Content("To Be Continued...");
        return RedirectToAction("EnterPaymentInfo");
      }
      return View();
    }

    // GET: /Rental/EnterPaymentInfo
    [HttpGet]
    public IActionResult EnterPaymentInfo()
    {
      //display a view to the user for entering the Payment Info
      CheckoutViewModel rentalcheckout = new CheckoutViewModel();
      return View(rentalcheckout);
    }

    // POST: /Rental/EnterPaymentInfo
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EnterPaymentInfo(bool paymentclear)
    {
      if (ModelState.IsValid) {
        //add code to save the data to Rentals Table
        return Content("Thank You for Renting with Us!");
        //return RedirectToAction("UserHome", "User");
      }
      return View();
    }

  }    
}