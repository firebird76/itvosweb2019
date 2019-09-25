using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStart.Models;

namespace WebStart.Controllers
{
  public class BeispielController : Controller
  {
    public string Index(string vorname, string nachname)
    {
      return $"Hallo {vorname} {nachname}";
    }

    public int Summe(int a, int b)
    {
      return a + b;
    }

    public string Hallo(Person person)
    {
      return $"Hallo {person.Vorname} {person.Nachname}";
    }

    public Person Meier()
    {
      return new Person { Vorname = "Uwe", Nachname = "Meier" };
    }

    public IEnumerable<Person>Alle()
    {
      return Person.Personen;
    }

    public async Task<ActionResult<Person>> Eine(int id)
    {
      await Task.Delay(2000);
      var person = Person.Personen.SingleOrDefault(p => p.Id == id);
      if (person == null)
        return NotFound("Person mit id " + id + " nicht vorhanden");
      return Ok(person);
    }

    public FileResult Download()
    {
      return File(Encoding.UTF8.GetBytes("<abc>Hallo</abc>"), "application/xml");
    }
  }
}