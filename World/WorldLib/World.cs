using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorldLib
{
  public class World
  {
    private readonly MondialContext mondialContext;

    public World(MondialContext mondialContext)
    {
      this.mondialContext = mondialContext;
    }

    public async Task<IEnumerable<Continent>> GetContinentsAsync()
    {
      return await mondialContext.Continents.ToListAsync();
    }

    public void InitDb(string xml)
    {
      XDocument xDoc = XDocument.Parse(xml);
      var continents = xDoc.Root.Elements("continent")
        .Select(xContinent => new Continent
        {
          Name = xContinent.Element("name").Value,
          Area = (int)xContinent.Element("area"),
          Countries = xDoc.Root.Elements("country")
          .Where(xCountry => xCountry.Element("encompassed").Attribute("continent").Value == xContinent.Attribute("id").Value)
          .Select(xCountry => new Country
          {
            Name = xCountry.Element("name").Value,
            CarCode = xCountry.Attribute("car_code").Value,
            Population = (int)xCountry.Element("population"),
            Cities = xCountry.Descendants("city")
                           .Select(xCity => new City
                           {
                             Name = xCity.Element("name").Value,
                             Population = (int?)xCity.Element("population")
                           }).ToList()
          })
         .ToList()
        })
      .ToList();

      mondialContext.Continents.AddRange(continents);
      mondialContext.SaveChanges();
    }

  }
}
