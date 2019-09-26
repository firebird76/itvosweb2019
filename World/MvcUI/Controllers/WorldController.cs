using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;
using WorldLib;

namespace MvcUI.Controllers
{
  public class WorldController : Controller
  {
    private readonly World world;

    public WorldController(World world)
    {
      this.world = world;
    }

    public async Task<IActionResult> Index()
    {
      var continents = await world.GetContinentsAsync();
      return View(continents);
    }

    public IActionResult InitDb()
    {
      return View();
    }

    [HttpPost]
    public IActionResult InitDb(FileUploadVM fileToUploadVM)
    {
      if (fileToUploadVM.FileToUpload.FileName.ToLower() != "mondial.xml")
        return this.BadRequest("Bitte nur Datei mondial.xml laden");

      var stream = fileToUploadVM.FileToUpload.OpenReadStream();
      string xml;

      using (var sr = new StreamReader(stream))
      {
        xml = sr.ReadToEnd();
      }

      world.InitDb(xml);

      return RedirectToAction("Index");
    }

    public async Task<IActionResult>Countries(int continentId)
    {
      var countries = await world.GetCountriesOfContinent(continentId);
      ViewBag.Continent = await world.GetContinentAsync(continentId);
      return View(countries);
    }

    public async Task<IActionResult>CountriesPartial(int continentId)
    {
      var countries = await world.GetCountriesOfContinent(continentId);
      return PartialView(countries);
    }
  }
}