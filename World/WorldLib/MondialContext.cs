using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldLib
{
  public class MondialContext: DbContext
  {
    public DbSet<Continent> Continents { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    public MondialContext(DbContextOptions<MondialContext> options):base(options)
    {
    }
  }
}
