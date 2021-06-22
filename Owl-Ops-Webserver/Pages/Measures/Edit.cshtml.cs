using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Owl_Ops_Webserver.Model;

namespace Owl_Ops_Webserver.Pages.Measures
{
    public class EditModel : PageModel
    {
        private readonly Owl_Ops_Webserver.Model.OwlDatabaseContext _context;

        public EditModel(Owl_Ops_Webserver.Model.OwlDatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Measurement Measurement { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Measurement = await _context.Measurements
                .Include(m => m.Sensor).FirstOrDefaultAsync(m => m.ID == id);

            if (Measurement == null)
            {
                return NotFound();
            }
           ViewData["Sensor_ID"] = new SelectList(_context.Sensors, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(Measurement.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.ID == id);
        }
    }
}
