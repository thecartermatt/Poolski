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
    public class DeleteModel : PageModel
    {
        private readonly Poolski.API.Data.DataContext _context;

        public DeleteModel(Poolski.API.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trips.FirstOrDefaultAsync(m => m.Id == id);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trips.FindAsync(id);

            if (Trip != null)
            {
                _context.Trips.Remove(Trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
