using System;
using System.Collections.Generic;

namespace WorldLib
{
  public class Continent
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Area { get; set; }

    public IEnumerable<Country> Countries { get; set; }
  }
}
