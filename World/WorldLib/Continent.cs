using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldLib
{
  public class Continent
  {
    public int Id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 4)]
    [Display(Name="Kontinentname")]
    public string Name { get; set; }

    [Range(1000,999999999)]
    [Display(Name="Fläche")]
    public int Area { get; set; }

    [JsonIgnore]
    public IEnumerable<Country> Countries { get; set; }
  }
}
