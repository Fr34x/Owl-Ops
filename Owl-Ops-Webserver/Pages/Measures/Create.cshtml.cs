using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Owl_Ops_Webserver.Model;

namespace Owl_Ops_Webserver.Pages.Measures
{
    public class CreateModel : PageModel
    {
        private readonly Owl_Ops_Webserver.Model.OwlDatabaseContext _context;

        public CreateModel(Owl_Ops_Webserver.Model.OwlDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Sensor_ID"] = new SelectList(_context.Sensors, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Measurement Measurement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Measurements.Add(Measurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
