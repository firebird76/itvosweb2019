using System;
using System.Collections.Generic;
using System.Text;

namespace WorldLib
{
  public class Country
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string CarCode { get; set; }
    public int Population { get; set; }

    public IEnumerable<City> Cities { get; set; }

    public Continent Continent { get; set; }
    public int ContinentId { get; set; }
  }
}
