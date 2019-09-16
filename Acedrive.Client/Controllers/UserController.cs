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
      //display a view for entering Registration Info for User
      User client = new User();
      return View(client);
    }

    // POST: /User/UserRegistration
    [HttpPost]
    public IActionResult UserRegistration(User u)
    {
      if (ModelState.IsValid) {
        //saves Registration info to the User table
        _session.RegisterUser(u);
        var user = _session.ReadUser();
        return RedirectToAction("RentalPeriodSelection", "Rental");
        //return Content("$You're good to go!");
      }
      return View();
    }
  }
}