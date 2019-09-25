using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beispiel2.Models
{
  public class Firmenservice
  {
    public string GetName()
    {
      return "ABC";
    }

    public IEnumerable<Person>GetMitarbeiter()
    {
      return Person.Personen;
    }
  }
}
