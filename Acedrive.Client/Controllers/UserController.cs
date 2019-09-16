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
    public IActionResult UserLogin(string email, string password)
    {
      if (ModelState.IsValid) {
        bool isemailcorrect = _session.ValidateUser(email, password);
        if (isemailcorrect == true) {
          return RedirectToAction("RentalPeriodSelection", "Rental");
        } else {
          return RedirectToAction("UnsuccessfulLogin", "User");
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

  }
}