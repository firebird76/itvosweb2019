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
    public class IndexModel : PageModel
    {
        private readonly WorldLib.MondialContext _context;

        public IndexModel(WorldLib.MondialContext context)
        {
            _context = context;
        }

        public IList<Continent> Continent { get;set; }

        public async Task OnGetAsync()
        {
            Continent = await _context.Continents.ToListAsync();
        }
    }
}
