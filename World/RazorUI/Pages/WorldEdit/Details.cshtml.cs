using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorldLib;

namespace RazorUI.Pages.WorldEdit
{
    public class DetailsModel : PageModel
    {
        private readonly WorldLib.MondialContext _context;

        public DetailsModel(WorldLib.MondialContext context)
        {
            _context = context;
        }

        public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Continent = await _context.Continents.FirstOrDefaultAsync(m => m.Id == id);

            if (Continent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
