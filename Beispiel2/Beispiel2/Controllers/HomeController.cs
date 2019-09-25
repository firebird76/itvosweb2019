using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Beispiel2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Beispiel2.Controllers
{
  public class HomeController : Controller
  {
    private readonly IConfiguration configuration;
    private readonly ILogger<HomeController> logger;
    private readonly Firmenservice firmenservice;

    public HomeController(IConfiguration configuration, 
      ILogger<HomeController> logger,
      Firmenservice firmenservice)
    {
      this.configuration = configuration;
      this.logger = logger;
      this.firmenservice = firmenservice;
      logger.LogInformation("HomeController instanziert");
    }

    public IActionResult Index()
    {
      logger.LogError("Index aufgerufen");

      ViewData["Firma"] = firmenservice.GetName();
      ViewBag.Info = configuration.GetValue<string>("geheim");

      return View(firmenservice.GetMitarbeiter());
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
