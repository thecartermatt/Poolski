using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Poolski.API.Data;
using Poolski.API.Models;

namespace Poolski.web.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly Poolski.API.Data.DataContext _context;

 
        [BindProperty]
        public int FromLocationId { get; set; }
        [BindProperty]
        public int ToLocationId { get; set; }

        public List<Location> Locations { get; set; }

        public CreateModel(Poolski.API.Data.DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
         
            var locations = await _context.Locations.OrderBy(a => a.Name).ToListAsync();
            Locations = locations;
            string i = User.Identity.GetUserId();
      
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Trip.FromLocation = _context.Locations.FirstOrDefault(l => l.Id == FromLocationId);
            Trip.ToLocation = _context.Locations.FirstOrDefault(l => l.Id == ToLocationId);
   

            _context.Trips.Add(Trip);
            await _context.SaveChangesAsync(); 

            return RedirectToPage("./Index");
        }
    }
}