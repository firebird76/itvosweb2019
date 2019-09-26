using System;
using System.Collections.Generic;
using System.Text;

namespace WorldLib
{
  public class City
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public int? Population { get; set; }

    public Country Country { get; set; }
    public int CountryId { get; set; }


  }
}
