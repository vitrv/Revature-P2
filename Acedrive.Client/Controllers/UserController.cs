using System;
using System.Collections.Generic;
using Acedrive.Client.Models;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers {
  public class UserController : Controller {
    Session _session = SessionHandler.Instance();

    // GET: /User/UserRegistration
    [HttpGet]
    public IActionResult UserRegistration()
    {
      User client = new User();
      return View(client);
    }

    // POST: /User/UserRegistration
    [HttpPost]
    public IActionResult UserRegistration(User u)
    {
      if (ModelState.IsValid) {
        _session.RegisterUser(u);
        var user = _session.ReadUser();
        _session.SaveNewUser(user);
        
        return RedirectToAction("RentalPeriodSelection", "Rental");
      }
      return View();
    }

    // GET: /User/UserLogin
    [HttpGet]
    public IActionResult UserLogin()
    {
      User client = new User();
      return View(client);
    }

    // POST: /User/UserLogin
    [HttpPost]
    public IActionResult UserLogin(string email, string password)
    {
      if (ModelState.IsValid) {
        bool doesuserexist = _session.ValidateUser(email, password);
        if (doesuserexist == true) {
          _session.GetUserInfo(email, password);
          return RedirectToAction("UserPortal");
        } else {
          return RedirectToAction("UnsuccessfulLogin");
        }
      }
      return View();
    }

    // GET: /User/UnsuccessfulLogin
    [HttpGet]
    public IActionResult UnsuccessfulLogin()
    {
      return View();
    }

    // POST: /User/UnsuccessfulLogin
    [HttpPost]
    public IActionResult UnsuccessfulLogin(string decision)
    {
      if (ModelState.IsValid) {
        if (decision == "login") {
          return RedirectToAction("UserLogin");
        } else if (decision == "signup") {
          return RedirectToAction("UserRegistration");
        } else if (decision == "gohome") {
          return RedirectToAction("Index", "Home");
        }
      }
      return View();
    }

    // GET: /User/UserRentalHistory
    [HttpGet]
    public IActionResult UserRentalHistory(string email, string password)
    {
      UserRentalHistoryViewModel urhistory = new UserRentalHistoryViewModel();
      if (email != null && password != null) {
        _session.GetUserInfo(email, password);
      } 
      
      urhistory.DisplayNameofUser(_session.ReadUser().FirstName);
      urhistory.DisplayRentalDates(_session.ReadTime("start"), _session.ReadTime("end"), _session.ReadTime("payment"));
      urhistory.DisplayStoreLocation(_session.ReadLocation());
      urhistory.DisplayRentedVehicle(_session.ReadVehicle());
      urhistory.DisplayAmountPaid(_session.ReadPayment());
      return View(urhistory);
    }

    // POST: /User/UserRentalHistory
    [HttpPost]
    public IActionResult UserRentalHistory(string decision)
    {
      if (ModelState.IsValid) {
        if (decision == "userportal") {
          return RedirectToAction("UserPortal");
        } else if (decision == "logout") {
          return RedirectToAction("Index", "Home");
        }
      }
      return View();
    }

    // GET: /User/UserPortal
    [HttpGet]
    public IActionResult UserPortal()
    {
      ViewBag.Name = _session.ReadUser().FirstName;
      return View();
    }

    // POST: /User/UserPortal
    [HttpPost]
    public IActionResult UserPortal(string decision)
    {
      if (ModelState.IsValid) {
        if (decision == "newrental") {
          return RedirectToAction("RentalPeriodSelection", "Rental");
        } else if (decision == "userhistory") {
          return RedirectToAction("UserRentalHistory");
        } else if (decision == "logout") {
          return RedirectToAction("Index", "Home");
        }
      }
      return View();
    }

  }
}