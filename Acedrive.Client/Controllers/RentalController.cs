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
        return RedirectToAction("LocationSelection", "Location");
      }
      return View();
    }

    // GET: /Rental/DisplayRentalDetails
    [HttpGet]
    public IActionResult DisplayRentalDetails()
    {
      Payment userpayment = _session.GetRentalPayment();
      
      RentalOrderViewModel rentalparts = new RentalOrderViewModel();
      rentalparts.DisplayRentalPeriod(_session.ReadTime("start"), _session.ReadTime("end"));
      rentalparts.DisplayStoreLocation(_session.ReadLocation());
      rentalparts.DisplayRentalVehicleType(_session.ReadVehicleType());
      rentalparts.DisplayRentalVehicle(_session.ReadVehicle());
      rentalparts.DisplayRentalPayment(userpayment);
      return View(rentalparts);
    }

    // POST: /Rental/DisplayRentalDetails
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DisplayRentalDetails(bool rentalclear)
    {
      if (ModelState.IsValid) {
        return RedirectToAction("EnterPaymentInfo");
      }
      return View();
    }

    // GET: /Rental/EnterPaymentInfo
    [HttpGet]
    public IActionResult EnterPaymentInfo()
    {
      CheckoutViewModel rentalcheckout = new CheckoutViewModel();
      return View(rentalcheckout);
    }

    // POST: /Rental/EnterPaymentInfo
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EnterPaymentInfo(bool paymentclear)
    {
      if (paymentclear == true) {
        Rental validatedrental = new Rental {
          StartDate = _session.ReadStartDate(),
          EndDate = _session.ReadEndDate(),
          UserRefId = _session.ReadUser().UserId,
          LocationRefId = _session.ReadLocation().LocationId,
          VehicleRefId = _session.ReadVehicle().VehicleId,
          RentalCost = _session.ReadPayment(),
          VehicleStatus = true
        };

        _session.AddRental(validatedrental);
        _session.SaveNewRental(validatedrental);

        Payment validatedpayment = new Payment {
          RentalRefId = _session.ReadRental().RentalId,
          PaymentDate = DateTime.Now,
          PaymentAmount = _session.ReadPayment()
        };

        _session.AddPaymentDate(validatedpayment.PaymentDate.ToString("D"));
        _session.SavePayment(validatedpayment);
        return RedirectToAction("AfterPaymentAction");
      }
  
      return View();
    }

    // GET: /Rental/AfterPaymentAction
    [HttpGet]
    public IActionResult AfterPaymentAction()
    {
      return View();
    }

    // POST: /Rental/AfterPaymentAction
    [HttpPost]
    public IActionResult AfterPaymentAction(string decision)
    {
      if (ModelState.IsValid) {
        if (decision == "anotherrental") {
          return RedirectToAction("RentalPeriodSelection");
        } else if (decision == "viewhistory") {
          return RedirectToAction("UserRentalHistory", "User");
        } else if (decision == "userportal") {
          return RedirectToAction("UserPortal", "User");
        } else if (decision == "logout") {
          return RedirectToAction("UserLogout", "User");
        }
      }
      return View();
    }
  }    
}