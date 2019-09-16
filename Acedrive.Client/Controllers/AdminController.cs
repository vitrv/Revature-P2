using System.Collections.Generic;
using Acedrive.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Acedrive.Client.Controllers
{
  public class AdminController : Controller
  {
    Session _session = SessionHandler.Instance();

    [HttpGet]
    public IActionResult AddVehicleType()
    {

      return View();
    }

    [HttpPost]
    public IActionResult AddVehicleType()
    {
      
      return View();
    }
  
  }
}
