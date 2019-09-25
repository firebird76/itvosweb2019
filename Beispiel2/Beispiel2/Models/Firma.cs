using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beispiel2.Models
{
  public class FirmaVM
  {
    public string Name { get; set; }
    public IEnumerable<Person> Mitarbeiter { get; set; }
  }
}
