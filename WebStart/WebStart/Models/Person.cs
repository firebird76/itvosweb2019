using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStart.Models
{
  public class Person
  {
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public int Id { get; set; }

    public static List<Person> Personen = new List<Person>
    {
      new Person{Id=1, Nachname="Meier", Vorname="Dieter"},
      new Person{Id=2, Nachname="Müller", Vorname="Gisela"},
      new Person{Id=3, Nachname="Duck", Vorname="Dagobert"}
    };
  }
}
