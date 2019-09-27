using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldLib;

namespace WorldApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class WorldController : ControllerBase
  {
    private readonly MondialContext _context;
    private readonly World world;

    public WorldController(MondialContext context, World world)
    {
      _context = context;
      this.world = world;
    }

    // GET: api/Continents
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Continent>>> GetContinents()
    {
      return await _context.Continents.ToListAsync();
    }

    [HttpGet("{continentid}/countries")]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountriesOfContinent(int continentId)
    {
      return Ok(await world.GetCountriesOfContinent(continentId));
    }
  }
}