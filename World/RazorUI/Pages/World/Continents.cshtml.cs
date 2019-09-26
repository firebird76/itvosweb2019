using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorUI.Pages.World
{
  public class ContinentsModel : PageModel
  {
    private readonly WorldLib.World world;

    public ContinentsModel(WorldLib.World world)
    {
      this.world = world;
    }

    public IEnumerable<WorldLib.Continent> Continents { get; set; }
    public async Task OnGet()
    {
      Continents = await world.GetContinentsAsync();
    }
  }
}