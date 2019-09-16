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

      return View();
    }
  }
}