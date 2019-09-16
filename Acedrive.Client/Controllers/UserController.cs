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

    // GET: /User/UserRegistration
    [HttpGet]
    public IActionResult UserLogin()
    {
      User client = new User();
      return View(client);
    }

    // POST: /User/UserLogin
    [HttpPost]
    public IActionResult UserLogin(User u)
    {
      if (ModelState.IsValid) {
        _session.RegisterUser(u);
        var user = _session.ReadUser();
        _session.SaveNewUser(user);
        
        return RedirectToAction("RentalPeriodSelection", "Rental");
      }
      return View();
    }

  }
}