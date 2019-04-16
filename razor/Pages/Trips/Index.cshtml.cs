using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Data;
using Poolski.API.Models;

namespace Poolski.web.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly Poolski.API.Data.DataContext _context;

        public IndexModel(Poolski.API.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Trip> Trip { get;set; }

        public async Task OnGetAsync()
        {
            Trip = await _context.Trips.ToListAsync();
        }
    }
}
