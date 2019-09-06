using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Acedrive.Client.Models;
using Microsoft.Extensions.Options;

namespace Acedrive.Client.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ConnectionString _cs;
        public HomeController(IOptions<ConnectionString> ConnectionString)
        {      
          _cs = ConnectionString.Value ?? throw new ArgumentException(nameof(ConnectionString));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content($"Connection string: {_cs.Secret}");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
