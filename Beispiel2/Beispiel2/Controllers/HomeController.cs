using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Beispiel2.Models;
using Microsoft.Extensions.Configuration;

namespace Beispiel2.Controllers
{
  public class HomeController : Controller
  {
    private readonly IConfiguration configuration;

    public HomeController(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    public IActionResult Index()
    {
      ViewData["Firma"] = "Hinz und Kunz";
      ViewBag.Info = configuration.GetValue<string>("Info");

      return View(Person.Personen);
    }

    public IActionResult Seite2()
    {
      var vm = new FirmaVM { Mitarbeiter = Person.Personen, Name = "Müller & Sohn" };
      return View(vm);
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
